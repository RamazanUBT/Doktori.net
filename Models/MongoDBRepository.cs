using MongoDB.Bson;
using MongoDB.Driver;

namespace Doktori.Models
{
    public class MongoDBRepository
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName = "Admin";

        public MongoDBRepository(IMongoDatabase database)
        {
            _database = database;
        }

        // Add MongoDB operations here...
        public void SaveDocument(BsonDocument document)
        {
            var collection = _database.GetCollection<BsonDocument>(_collectionName);
            collection.InsertOne(document);
        }
    }
}
