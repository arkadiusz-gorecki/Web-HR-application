using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // foreign key
//using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace job_application_project.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter company name.")]
        [MinLength(3, ErrorMessage = "Company name length can't be less than 3 characters.")]
        [MaxLength(30, ErrorMessage = "Company name length can't be more than 30 characters.")]
        public string Name { get; set; }
        [ForeignKey("CompanyId")]
        public ICollection<JobOffer> JobOffers { get; set; }
    }
}
