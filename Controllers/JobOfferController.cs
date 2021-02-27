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
    public class JobOfferController: Controller
    {
        private readonly DataContext _context;

        public JobOfferController(DataContext dt)
        {
            _context = dt;
        }

        public IActionResult Index()
        {
            return View(_context.JobOffers.ToList());
        }

        public IActionResult Details(int id)
        {
            JobOffer model = _context.JobOffers.Include(x => x.Company).FirstOrDefault(x => x.Id == id);
            model.JobApplications = _context.JobApplications.Where(x => x.JobOfferId == id).ToList();
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            JobOfferCreateView model = new JobOfferCreateView
            {
                Companies = _context.Companies.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(JobOfferCreateView model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = _context.Companies.ToList();
                return View(model);
            }
            
            model.Created = DateTime.Now;
            _context.JobOffers.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            JobOffer jo = _context.JobOffers.FirstOrDefault(x => x.Id == id);
            JobOfferCreateView jocv = new JobOfferCreateView
            {
                Id = jo.Id,
                CompanyId = jo.CompanyId,
                JobTitle = jo.JobTitle,
                SalaryFrom = jo.SalaryFrom,
                SalaryTo = jo.SalaryTo,
                Created = jo.Created,
                Location = jo.Location,
                Description = jo.Description,
                ValidUntil = jo.ValidUntil,
                Companies = _context.Companies.ToList()
            };
            return View(jocv);
        }
        [HttpPost]
        public IActionResult Edit(JobOfferCreateView model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = _context.Companies.ToList();
                return View(model);
            }
            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id) // ta metode nie ma get
        {
            JobOffer jo = _context.JobOffers.FirstOrDefault(x => x.Id == id);
            _context.Remove(jo);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
