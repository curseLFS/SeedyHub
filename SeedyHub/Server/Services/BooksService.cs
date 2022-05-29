
using SeedyHub.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SeedyHub.Client.Services
{
    public class BooksService
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public BooksService(IOptions<BookStoreDatabaseSettings> bookStoreDataSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDataSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDataSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
                bookStoreDataSettings.Value.BooksCollectionName);
        }

        public async Task<List<Book>> GetASync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetASync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Book updateBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updateBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
