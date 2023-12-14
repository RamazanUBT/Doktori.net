using Doktori.Models;
using Doktori.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Diagnostics;

namespace Doktori.Controllers
{
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

        public IActionResult Welcome()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SubmitAdminLogin(AdminLogin model)
        {
            if (ModelState.IsValid)
            {
                // Access model.Email and model.Password and save to MongoDB using MongoDBRepository

                // Example: Save data to MongoDB
                var document = new BsonDocument
            {
                { "Email", model.Email },
                { "Password", model.Password }
            };

                // Access the MongoDBRepository and save the document
                _mongoDBRepository.SaveDocument(document);

                // Redirect or return a response as needed
                return RedirectToAction("Welcome");
            }

            // If the model is not valid, redisplay the form with validation errors
            return View("AdminLogin", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
