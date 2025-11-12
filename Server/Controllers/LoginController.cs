using AuthService;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class LoginController(
    LoginService loginService
) : Controller {
    [HttpGet]
    public IActionResult login() {
        ViewData["Title"] = "Login";
        return View();
    }

    [HttpPost]
    public IActionResult login(string username, string password) {
        ViewData["Title"] = "Login processing...";

        string token;
        try {
            token = loginService.login(username, password);
        } catch (Exception) {
            return BadRequest();
        }

        return Ok(token);
    }
}