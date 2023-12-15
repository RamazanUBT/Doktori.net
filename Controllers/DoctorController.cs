using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doktori.Interface;
using Doktori.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(DoctorEntity doctorData)
        {
            _context.Create(doctorData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var doctorDetails = _context.GetDoctorDetails(id);
            return View(doctorDetails);
        }

        [HttpPost]
        public IActionResult EditPost(string _id, DoctorEntity doctorData)
        {
            _context.Update(_id, doctorData);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var doctorDetails = _context.GetDoctorDetails(id);
            return View(doctorDetails);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var doctorDetails = _context.GetDoctorDetails(id);
            return View(doctorDetails);
        }

        [HttpPost]
        public IActionResult DeletePost(string _id)
        {
            _context.Delete(_id);
            return RedirectToAction("Index");
        }
    }
}

