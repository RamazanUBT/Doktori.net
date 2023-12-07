using MongoDB.Driver;

namespace Doktori.Models
{
    public class MongoDBRepository
    {
        private readonly IMongoDatabase _database;

        public MongoDBRepository(IMongoDatabase database)
        {
            _database = database;
        }

        // Add MongoDB operations here...
    }
}
