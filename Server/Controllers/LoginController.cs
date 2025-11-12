using DataLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class LoginController(ILogger<LoginController> logger) : Controller {
    [HttpGet]
    public IActionResult login() {
        ViewData["Title"] = "Login";
        return View();
    }

    [HttpPost]
    public IActionResult login(string username, string password) {
        //ViewData["Title"] = "Login successful";
        logger.LogError($"Try to login with: {username}, {password}");

        var accountWithoutPassword = new AccountWithoutPassword(Guid.NewGuid(), username);
        var passwordHash = new PasswordHasher<AccountWithoutPassword>().HashPassword(accountWithoutPassword, password);
        var account = new Account(
            accountWithoutPassword.id,
            accountWithoutPassword.username,
            passwordHash
        );

        var result = new PasswordHasher<Account>().VerifyHashedPassword(account, account.passwordHash, password);

        if (result == PasswordVerificationResult.Success) {
            return new OkResult();
        } else {
            logger.LogError($"Password verification failed for user {username}");
            return new UnauthorizedResult();
        }
    }
}