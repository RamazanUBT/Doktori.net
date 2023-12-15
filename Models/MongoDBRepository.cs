using MongoDB.Bson;
using MongoDB.Driver;

namespace Doktori.Models
{
    public class MongoDBRepository
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<BsonDocument> _adminCollection;

        public MongoDBRepository(IMongoDatabase database)
        {
            _database = database;
            _adminCollection = _database.GetCollection<BsonDocument>("Admin");
        }

        // Add MongoDB operations here...

        public bool UserExists(string email, string password)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Email", email) & Builders<BsonDocument>.Filter.Eq("Password", password);
            var admin = _adminCollection.Find(filter).FirstOrDefault();
            return admin != null;
        }

        /*public void SaveDocument(BsonDocument document)
        {
            var collection = _database.GetCollection<BsonDocument>(_collectionName);
            collection.InsertOne(document);
        }*/
    }
}
