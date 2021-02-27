using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using job_application_project.EntityFramework;
using job_application_project.Models;

namespace job_application_project.Controllers
{
    public class CompanyController : Controller
{
        private readonly DataContext _context;
        public CompanyController(DataContext dt)
        {
            _context = dt;
        }
        public IActionResult Index()
        {
            return View(_context.Companies.ToList());
        }
        public IActionResult Details(int id)
        {
            Company model = _context.Companies.FirstOrDefault(x => x.Id == id);
            model.JobOffers = _context.JobOffers.Where(x => x.CompanyId == id).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.Companies.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public IActionResult Edit(Company model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id) // ta metode nie ma get
        {
            Company c = _context.Companies.FirstOrDefault(x => x.Id == id);
            _context.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Company());
        }
        [HttpPost]
        public IActionResult Add(Company model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            
            _context.Companies.Add(model);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}