using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDemo.Models;

namespace MongoDemo;

public class BookStoreContext : DbContext
{
    public DbSet<Book> Books { get; init; }

    public static BookStoreContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<BookStoreContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);

    public BookStoreContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().ToCollection("Books");
    }
}