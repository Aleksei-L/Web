using Microsoft.Extensions.DependencyInjection;

namespace AuthService;

public static class Extensions {
    public static IServiceCollection AddAuthService(this IServiceCollection service) {
        service.AddScoped<IAccountsService, AccountsService>();
        return service;
    }
}