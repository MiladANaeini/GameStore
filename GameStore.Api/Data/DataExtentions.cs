namespace GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;

public static class DataExtentions
{
    public static void InitializeDb(this IServiceProvider serviceProvider){
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
        
    }
}