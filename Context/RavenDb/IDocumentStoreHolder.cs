using Raven.Client.Documents;

namespace Context.RavenDb
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore DocumentStore { get; }
    }
}
