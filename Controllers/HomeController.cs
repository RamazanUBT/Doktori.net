using Doktori.Models;
using Doktori.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly MongoDBRepository _mongoDBRepository;
    private readonly ILogger<HomeController> _logger;

    public HomeController(MongoDBRepository mongoDBRepository, ILogger<HomeController> logger)
    {
        _mongoDBRepository = mongoDBRepository;
        _logger = logger;
    }

  
    public IActionResult AdminLoginPage()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AdminLogin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitAdminLogin(AdminLogin model)
    {
        if (ModelState.IsValid)
        {
            // Check if the user exists in the database
            if (_mongoDBRepository.UserExists(model.Email, model.Password))
            {
                // Redirect to the Welcome action upon successful login
                return RedirectToAction("Welcome");
            }

            // If the model is not valid or login fails, redisplay the form with validation errors
            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your email and password.");
        }

        // Ensure the Email and Password properties are set to non-null values
        model.Email ??= "";  // Set to an empty string if null
        model.Password ??= ""; // Set to an empty string if null

        return View("AdminLoginPage", model);
    }

    public IActionResult Welcome()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
