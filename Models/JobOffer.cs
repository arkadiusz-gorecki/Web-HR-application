using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using job_application_project.Validation;
using System.ComponentModel.DataAnnotations.Schema; // foreign key

namespace job_application_project.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [Required(ErrorMessage = "Please insert job title.")]
        [MinLength(3, ErrorMessage = "Job title length can't be less than 3 characters.")]
        [MaxLength(25, ErrorMessage = "Job title length can't be more than 25 characters.")]
        public string JobTitle { get; set; }
        public decimal? SalaryFrom { get; set; }
        [ValidSalary("SalaryFrom", ErrorMessage = "Minimal salary cannot be greater than maximal salary")]
        public decimal? SalaryTo { get; set; }
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Please insert job location.")]
        [RegularExpression("[a-zA-Z][a-z]*([ ][a-zA-Z][a-z]*)*", ErrorMessage = "Location name must consist of letters only. Location name cannot start and/or end with space and cannot contain upper case letters inside the words.")] // nazwa miejscowości moze mieć spacje w środku ale nie na końcu i nie na początku, tylko pierwsza litera w wyrazach może być duża
        [MinLength(3, ErrorMessage = "Location name length can't be less than 3 characters.")]
        [MaxLength(25, ErrorMessage = "Location name length can't be more than 25 characters.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please write job description.")]
        [MinLength(5, ErrorMessage = "Description length can't be less than 5 characters.")]
        [MaxLength(250, ErrorMessage = "Description length can't be more than 250 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please choose a date.")]
        public DateTime? ValidUntil { get; set; }
        [ForeignKey("JobOfferId")]
        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
