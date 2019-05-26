using System;
using Xunit;
using Raven.Client.Documents;
using Raven.TestDriver;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;
using Entities;

namespace DataTests
{
    public class RavenDbTests : RavenTestDriver, IAsyncLifetime
    {
        private IDocumentStore _store;
        private IAsyncDocumentSession _session;

        public async Task InitializeAsync()
        {
            _store = GetDocumentStore();
            _session = _store.OpenAsyncSession();
            
            await _session.StoreAsync(RavenDocumentHelper.GetBibleByte());
            await _session.StoreAsync(RavenDocumentHelper.GetBibleByte());

            await _session.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await Task.Run(() => _store.Dispose());
            await Task.Run(() => _session.Dispose());
        }


        [Fact]
        public async Task TestAThing()
        {
            var docs = await _session.Query<BibleByte>().ToListAsync();
            Assert.True(docs.Count == 2);
        }
    }
}
