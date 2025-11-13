using Data;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService;

public class AppContext(DbContextOptions options) : DbContext(options) {
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Account>().HasKey(it => it.Id);
        base.OnModelCreating(modelBuilder);
    }
}