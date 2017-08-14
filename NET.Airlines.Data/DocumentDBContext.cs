using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data
{
    public class DocumentDBContext<T> where T : Entity.EntityBase
    {
        private string endpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
        private string authorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];
        private string databaseId = ConfigurationManager.AppSettings["databaseId"];
        private int collectionPerformance = Convert.ToInt16(ConfigurationManager.AppSettings["collectionPerformance"]); 

        private readonly DocumentClient client;
        private readonly Database database;
        private DocumentCollection collection;

        public DocumentDBContext() : this(null)
        {
        }

        public DocumentDBContext(string collectionId)
        {
            client = new DocumentClient(new Uri(endpointUrl), authorizationKey);

            database = client.CreateDatabaseIfNotExistsAsync(
                new Database
                {
                    Id = databaseId
                }).Result;

            if (null != collectionId)
                CreateDocumentCollectionIfNotExists(collectionId);
        }

        private void CreateDocumentCollectionIfNotExists(string collectionId)
        {
            collection = client.CreateDocumentCollectionIfNotExistsAsync(database.SelfLink,
                    new DocumentCollection()
                    {
                        Id = collectionId
                    },
                    new RequestOptions()
                    {
                        OfferThroughput = collectionPerformance
                    }).Result;
        }

        public T Delete(T entity)
        {
            dynamic doc = client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(database.Id, collection.Id, entity.Id));
            return entity;
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public T Get(T entity)
        {
            T t = null;

            dynamic doc = client.CreateDocumentQuery<Document>(collection.SelfLink)
                .Where(i => i.Id == entity.Id).AsEnumerable().FirstOrDefault();

            if (null != doc)
            {
                t = doc;
            }

            return t;
        }

        public IEnumerable<T> GetAll(T entity)
        {
            return client.CreateDocumentQuery<Document>(collection.SelfLink).AsEnumerable() as IEnumerable<T>;
        }

        public async Task<T> Insert(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            ResourceResponse<Document> doc = await client.CreateDocumentAsync(collection.SelfLink, entity);
            entity.Id = doc.Resource.Id;
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            dynamic doc = client.CreateDocumentQuery<Document>(collection.SelfLink)
                .Where(i => i.Id == entity.Id).AsEnumerable().FirstOrDefault();

            if (null != doc)
            {
                entity.ModifiedDate = DateTime.Now;
                ResourceResponse<Document> x = await client.ReplaceDocumentAsync(doc.SelfLink, entity);
            }

            return entity;
        }
    }
}