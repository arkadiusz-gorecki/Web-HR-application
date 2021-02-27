using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // foreign key

namespace job_application_project.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        [ForeignKey("JobOffer")]
        public int JobOfferId { get; set; }
        [ForeignKey("JobOfferId")]
        public JobOffer JobOffer { get; set; }
        [Required(ErrorMessage = "Please insert your first name.")]
        [MinLength(3, ErrorMessage = "First name length can't be less than 3 characters.")]
        [MaxLength(15, ErrorMessage = "First name length can't be more than 15 characters.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please insert your last name.")]
        [MinLength(3, ErrorMessage = "Last name length can't be less than 3 characters.")]
        [MaxLength(15, ErrorMessage = "Last name length can't be more than 15 characters.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please insert your phone number.")]
        [Phone(ErrorMessage = "Plesae enter a valid phone number.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please insert your email address.")]
        [EmailAddress(ErrorMessage = "Plesae enter a valid e-mail address.")]
        public string EmailAddress { get; set; }
        [Required]
        public bool ContactAgreement { get; set; }
        [Required(ErrorMessage = "Please insert your CV url(web address).")]
        [Url(ErrorMessage = "Please enter a valid fully-qualified http, https, or ftp URL.")]
        public string CvUrl { get; set; }
    }
}
