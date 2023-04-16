namespace Blog.Web.Controllers;

using System.Text;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Core.Models.User;
using Core.Services.Contracts;

[Authorize]
public class ApplicationUserController : Controller
{
    private readonly IApplicationUserService userService;

    public ApplicationUserController(IApplicationUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        if (HttpContext.Session.Get("userId") != null)
        {
            return RedirectToAction("All", "Article");
        }

        var model = new RegisterViewModel();

        return View(model);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid 
            || await userService.UsernameExistsAsync(model.UserName)
            || await userService.EmailExistsAsync(model.Email)
            || model.Password != model.ConfirmPassword)
        {
            return View(model);
        }

        await userService.CreateUserAsync(model);

        return RedirectToAction("Login");
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        if (HttpContext.Session.Get("userId") != null)
        {
            return RedirectToAction("All", "Article");
        }

        return View(new LoginViewModel());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Please enter all required fields!");
            return View(model);
        }

        string? userId = await userService.GetIdByUsernameAsync(model.UserName);

        if (userId == null)
        {
            ModelState.AddModelError("Username", "Invalid username!");
            return View(model);
        }

        if (!await userService.ValidateLoginInfoAsync(model))
        {
            ModelState.AddModelError("Username", "Invalid password!");
            return View(model);
        }
        
        HttpContext.Session.Set("userId", Encoding.UTF8.GetBytes(userId));
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}