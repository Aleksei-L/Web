using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace DatabaseService;

public class LoginService(
    ILogger<LoginService> logger,
    AccountsRepository accountsService,
    JwtService jwtService
) {
    private static readonly PasswordHasher<Account> passwordHasher = new();

    public string Login(string username, string password) {
        // TODO async operation on main thread
        var foundAccount = accountsService.GetAccountAsync(username).GetAwaiter().GetResult();
        if (foundAccount == null) {
            logger.LogWarning($"User {username} don't exist");
            throw new Exception($"User {username} don't exist");
        }

        var loginResult = passwordHasher.VerifyHashedPassword(foundAccount, foundAccount.PasswordHash, password);
        if (loginResult != PasswordVerificationResult.Success) {
            logger.LogWarning($"Password verification failed for user {username}");
            throw new Exception($"Password verification failed for user {username}");
        }

        logger.LogInformation($"Successful login with: {username}, {password}");
        return jwtService.GenerateToken(foundAccount);
    }

    public void Register(string username, string password) {
        var account = new Account {
            Id = Guid.NewGuid(),
            Username = username
        };

        var passwordHash = passwordHasher.HashPassword(account, password);
        account.PasswordHash = passwordHash;

        logger.LogInformation($"Successful register with: {username}, {password}");
        accountsService.CreateAccountAsync(account).Wait();
    }
}