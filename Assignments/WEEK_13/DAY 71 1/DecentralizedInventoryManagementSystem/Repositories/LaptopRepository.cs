using DecentrailzedInventoryManagementSystem.Models;
using DecentralizedInventoryManagementSystem.Repositories;
using DecentralizedInventoryManagementSystem.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DecentralizedInventoryManagementSystem.Repositories
{
    public class LaptopRepository : ILaptopRepository
    {
        private readonly IMongoCollection<Laptop> _collection;

        public LaptopRepository(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Laptop>(settings.Value.CollectionName);
        }

        public async Task<List<Laptop>> GetAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(Laptop laptop)
        {
            await _collection.InsertOneAsync(laptop);
        }
    }
}