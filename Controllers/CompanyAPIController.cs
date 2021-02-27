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
    [Route("api/Company/[action]")]
    [ApiController]
    public class CompanyAPIController : ControllerBase
    {
        private readonly DataContext _context;

        public CompanyAPIController(DataContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public Company GetCompany(int companyid)
        //{
        //    var c = _context.Companies.FirstOrDefault(x => x.Id == companyid);

        //    return c;
        //}

        /// <summary>
        /// Creates new company
        /// </summary>
        /// <param name="item">new company instance</param>
        /// <returns>Response 200 OK</returns>
        [HttpPost]
        public IActionResult SendCompany(Company item)
        {
            _context.Companies.Add(item);
            _context.SaveChanges();
            return Ok();
        }


    }
}