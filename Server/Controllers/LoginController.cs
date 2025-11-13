using DatabaseService;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class LoginController(
    LoginService loginService
) : Controller {
    [HttpGet]
    public IActionResult Login() {
        ViewData["Title"] = "Login";
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password) {
        ViewData["Title"] = "Login processing...";

        string token;
        try {
            token = loginService.Login(username, password);
        } catch (Exception) {
            return BadRequest();
        }

        return Ok(token);
    }

    [HttpPost]
    public IActionResult Register(string username, string password) {
        try {
            loginService.Register(username, password);
        } catch (Exception) {
            return BadRequest();
        }

        return Ok();
    }
}