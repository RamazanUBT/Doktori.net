using Doktori.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
