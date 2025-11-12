using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace AuthService;

public class LoginService(
    ILogger<LoginService> logger,
    JwtService jwtService
) {
    public string login(string username, string password) {
        var accountWithoutPassword = new AccountWithoutPassword(Guid.NewGuid(), username);
        var passwordHash = new PasswordHasher<AccountWithoutPassword>().HashPassword(accountWithoutPassword, password);
        var account = new Account(
            accountWithoutPassword.id,
            accountWithoutPassword.username,
            passwordHash
        );

        var loginResult = new PasswordHasher<Account>().VerifyHashedPassword(account, account.passwordHash, password);
        if (loginResult == PasswordVerificationResult.Failed) {
            logger.LogWarning($"Password verification failed for user {username}");
            throw new Exception($"Password verification failed for user {username}");
        }

        logger.LogInformation($"Successful login with: {username}, {password}");

        return jwtService.generateToken(account);
    }
}