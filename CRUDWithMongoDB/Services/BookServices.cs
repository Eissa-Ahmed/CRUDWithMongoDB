using CRUDWithMongoDB.Entities;
using CRUDWithMongoDB.Models;
using MongoDB.Driver;

namespace CRUDWithMongoDB.Services
{
    public class BookServices : IBookServices
    {
        private readonly IMongoCollection<Book> _bookCollection;
        public BookServices(DatabaseSettings settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);
            _bookCollection = mongoDatabase.GetCollection<Book>(settings.BookCollection);
        }
        public async Task CreateAsync(Book book)
        {
            await _bookCollection.InsertOneAsync(book);
        }

        public async Task DeleteAsync(string Id)
        {
            await _bookCollection.DeleteOneAsync(i => i.Id.Equals(Id));
        }

        public async Task<List<Book>> GetAsync()
        {
            return await _bookCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Book> GetAsync(string Id)
        {
            return await _bookCollection.Find(i => i.Id.Equals(Id)).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string Id, Book book)
        {
            await _bookCollection.ReplaceOneAsync(i => i.Id.Equals(Id), book);
        }
    }
}
