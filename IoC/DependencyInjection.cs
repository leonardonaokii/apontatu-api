using Domain.Interfaces.Services;
using Infra.DataBases;
using Infra.Persistance;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connection));
        
        services.AddScoped<ITimeKeepingService, TimeKeepingService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}