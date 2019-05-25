using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Context.RavenDb
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        private readonly ILogger<DocumentStoreHolder> _logger;

        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings, ILogger<DocumentStoreHolder> logger)
        {
            _logger = logger;
            var settings = ravenSettings.Value;

            DocumentStore = new DocumentStore()
            {
                Urls = new[] { settings.Url },
                Database = settings.Database
            };

            DocumentStore.Initialize();

            _logger.LogInformation("Initialized RavenDB document store for {0} at {1}",
                settings.Database, settings.Url);

            //Create indexes like so
            /*IndexCreation.CreateIndexes(
                typeof(Talks_BySpeaker).Assembly,
                Store
            );*/
        }

        public IDocumentStore DocumentStore { get; }
    }
}
