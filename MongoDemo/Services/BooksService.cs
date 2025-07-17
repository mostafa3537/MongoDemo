using System.Xml.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDemo.Models;

namespace MongoDemo.Services;

public class BooksService(IMongoDatabase database)
{
    private readonly BookStoreContext _context = BookStoreContext.Create(database);

    public async Task<List<Book>> GetAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetAsync(string id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task CreateAsync(Book newBook)
    {
        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(string id, Book updatedBook)
    {
        _context.Books.Update(updatedBook);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(string id)
    {
        var book = await GetAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}