using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseService;

public static class Extensions {
    public static void AddDatabaseAccess(this IServiceCollection serviceCollection) {
        serviceCollection.AddDbContext<AppContext>(it => {
            it.UseNpgsql("Host=localhost;Database=AccountsDb;Username=postgres;Password=postgres;");
        });
    }
}