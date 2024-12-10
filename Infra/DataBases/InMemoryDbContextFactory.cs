using Infra.Persistance;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Infra.DataBases;

public class InMemoryDbContextFactory
{
    public AppDbContext CreateContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;
        
        var context = new AppDbContext(options);
        
        context.Database.EnsureCreated();

        return context;
    }
}