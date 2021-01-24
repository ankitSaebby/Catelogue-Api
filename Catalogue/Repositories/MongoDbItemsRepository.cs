using System;
using System.Collections.Generic;
using Catalogue.Entities;
using MongoDB.Driver;

namespace Catalogue.Repositories
{
    public class MongoDbItemsRepository : IItemsRepositories
    {

        private const String dataBaseName="Catalogue";
        private const String collectionName="items";

        private readonly IMongoCollection<Item> itemsCollection;
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database =mongoClient.GetDatabase(dataBaseName);
            itemsCollection=database.GetCollection<Item>(collectionName);
        }
        public void CreateItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void upadateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}