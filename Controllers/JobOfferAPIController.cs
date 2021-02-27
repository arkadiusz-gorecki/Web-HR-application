using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using job_application_project.EntityFramework;
using job_application_project.Models;

namespace job_application_project.Controllers
{
    [Route("api/JobOffer/[action]")]
    [ApiController]
    public class JobOfferAPIController : ControllerBase
    {
        private readonly DataContext _context;

        public JobOfferAPIController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        ///  Creates new job offer
        /// </summary>
        /// <param name="item">new JobOffer instance</param>
        /// <returns>Response 200 OK</returns>
        [HttpPost]
        public IActionResult SendJobOffer(JobOffer item)
        {
            _context.JobOffers.Add(item);
            _context.SaveChanges();
            return Ok();
        }

    }
}