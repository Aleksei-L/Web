using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseService;

public static class Extensions {
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection) {
        serviceCollection.AddDbContext<AppContext>(it => {
            it.UseNpgsql("Host=localhost;Database=AccountsDb;Username=postgres;Password=postgres;");
        });
        return serviceCollection;
    }
}