using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using job_application_project.Models;
using job_application_project.EntityFramework;
using Microsoft.EntityFrameworkCore;


namespace job_application_project.Controllers
{ 
    public class JobApplicationController : Controller
    {

        private readonly DataContext _context;
        public JobApplicationController(DataContext dt)
        {
            _context = dt;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            JobApplication ja = _context.JobApplications.FirstOrDefault(x => x.Id == id);
            ViewBag.JobTitle = _context.JobOffers.FirstOrDefault(x => x.Id == ja.JobOfferId).JobTitle;
            
            return View(ja);
        }

        [HttpGet]
        public IActionResult Apply(int id) // parametrem jes Id JobOffer
        {
            ViewBag.JobTitle = _context.JobOffers.FirstOrDefault(x => x.Id == id).JobTitle;
            JobApplication model = new JobApplication
            {
                JobOfferId = id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Apply(JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.JobTitle = _context.JobOffers.FirstOrDefault(x => x.Id == model.JobOfferId).JobTitle;
                return View(model);
            }
            model.Id = 0; // nei wiem dlaczego ale submitowanie forma ustawia pole Id równe JobOfferId wiec trzeba z powrotem wyzerowac
            _context.JobApplications.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Details", "JobOffer", new { id = model.JobOfferId });

        }

        [HttpGet]
        public IActionResult Edit(int id) // parametrem jes Id JobApplication
        {
            JobApplication ja = _context.JobApplications.FirstOrDefault(x => x.Id == id);
            ViewBag.JobTitle = _context.JobOffers.FirstOrDefault(x => x.Id == ja.JobOfferId).JobTitle;
            return View(ja);
        }
        [HttpPost]
        public IActionResult Edit(JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.JobTitle = _context.JobOffers.FirstOrDefault(x => x.Id == model.JobOfferId).JobTitle;
                return View(model);
            }
            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = model.Id });
        }

        public IActionResult Delete(int id) // ta metode nie ma get
        {
            JobApplication ja = _context.JobApplications.FirstOrDefault(x => x.Id == id);
            _context.Remove(ja);
            _context.SaveChanges();
            //JobOffer jo = _context.JobOffers.FirstOrDefault(x => x.Id == ja.JobOfferId);
            return RedirectToAction("Details", "JobOffer", new { id = ja.JobOfferId });

        }
    }
}
