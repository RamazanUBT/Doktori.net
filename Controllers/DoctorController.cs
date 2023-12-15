using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doktori.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Doktori.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorsList _context;

        public DoctorController(IDoctorsList context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.GetAllDoctors());
        }
    }
}

