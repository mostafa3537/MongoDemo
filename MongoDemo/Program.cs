
using MongoDB.Driver;
using MongoDemo.Services;

namespace MongoDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var mongoClient = new MongoClient(builder.Configuration["BookStoreDatabase:ConnectionString"]);
            var mongoDatabase = mongoClient.GetDatabase(builder.Configuration["BookStoreDatabase:DatabaseName"]);
            builder.Services.AddSingleton(mongoDatabase);
            builder.Services.AddSingleton<BooksService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
