namespace GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;
using GameStore.Api.Repositories;

public static class DataExtentions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
        
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(connString)
                .AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();
        return services;
    }
}