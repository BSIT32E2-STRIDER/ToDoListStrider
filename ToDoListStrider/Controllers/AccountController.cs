using Microsoft.AspNetCore.Mvc;
using ToDoListStrider.Application;
using ToDoListStrider.Domain;
using ToDoListStrider.Models;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Register()
    {
       
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return View(model);
            }

           
            var existingUser = await _userService.GetUserByUsername(model.Username);
            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Username is already taken.");
                return View(model);
            }

           
            var newUser = new User
            {
                Username = model.Username,
                Password = model.Password
            };

            await _userService.Register(newUser);

            
            return RedirectToAction("Login");
        }

       
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            
            var user = await _userService.AuthenticateAsync(model.Username, model.Password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);

               
                return RedirectToAction("Index", "Home");
            }

           
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
        }

        
        return View(model);
    }

    [HttpPost]
    public IActionResult Logout()
    {
        
        HttpContext.Session.Clear();

        
        return RedirectToAction("Login");
    }
}
