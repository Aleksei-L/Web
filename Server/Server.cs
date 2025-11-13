using Data;
using DatabaseService;

namespace Server;

public static class Server {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<JwtService>();
        builder.Services.AddScoped<LoginService>();
        builder.Services.Configure<LoginSettings>(builder.Configuration.GetSection("LoginSettings"));
        builder.Services.AddScoped<AccountsRepository>();
        builder.Services.AddDatabaseAccess();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            "default",
            "{controller=Login}/{action=Login}/{id?}"
        ).WithStaticAssets();

        app.Run();
    }
}