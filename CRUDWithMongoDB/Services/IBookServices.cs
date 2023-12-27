using CRUDWithMongoDB.Entities;

namespace CRUDWithMongoDB.Services
{
    public interface IBookServices
    {
        public Task<List<Book>> GetAsync();
        public Task<Book> GetAsync(string Id);
        public Task CreateAsync(Book book);
        public Task DeleteAsync(string Id);
        public Task UpdateAsync(string Id, Book book);
    }
}
