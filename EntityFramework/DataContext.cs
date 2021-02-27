using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using job_application_project.Models;

namespace job_application_project.EntityFramework
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Auchan"
                },
                new Company
                {
                    Id = 2,
                    Name = "Tesco"
                },
                new Company
                {
                    Id = 3,
                    Name = "Biedronka"
                },
                new Company
                {
                    Id = 4,
                    Name = "Lewiatan"
                },
                new Company
                {
                    Id = 5,
                    Name = "Żabka"
                },
                new Company
                {
                    Id = 6,
                    Name = "Carrefour"
                }
            );
            modelBuilder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    Id = 1,
                    CompanyId = 1,
                    JobTitle = "Frontend",
                    SalaryFrom = 3000,
                    SalaryTo = 5000,
                    Created = new DateTime(2020, 1, 1),
                    Location = "Warsaw",
                    Description = "Nice work, I recommend",
                    ValidUntil = new DateTime(2020, 2, 1)

                },
                new JobOffer
                {
                    Id = 2,
                    CompanyId = 1,
                    JobTitle = "Backend",
                    SalaryFrom = 4500,
                    SalaryTo = 6500,
                    Created = new DateTime(2020, 1, 10),
                    Location = "Warsaw",
                    Description = "Fruit mondays",
                    ValidUntil = new DateTime(2020, 5, 10)

                },
                new JobOffer
                {
                    Id = 3,
                    CompanyId = 1,
                    JobTitle = "On dish",
                    SalaryFrom = 2200,
                    SalaryTo = 3200,
                    Created = new DateTime(2020, 1, 2),
                    Location = "Grojec",
                    Description = "Very dynamic team",
                    ValidUntil = new DateTime(2020, 1, 20)

                },
                new JobOffer
                {
                    Id = 4,
                    CompanyId = 2,
                    JobTitle = "Cashier",
                    SalaryFrom = 2200,
                    SalaryTo = 3200,
                    Created = new DateTime(2020, 1, 2),
                    Location = "Piaseczno",
                    Description = "Comfortable armchair",
                    ValidUntil = new DateTime(2020, 1, 20)
                },
                new JobOffer
                {
                    Id = 5,
                    CompanyId = 2,
                    JobTitle = "Warehouseman",
                    SalaryFrom = 2200,
                    SalaryTo = 3200,
                    Created = new DateTime(2020, 1, 2),
                    Location = "Piaseczno",
                    Description = "Easy job",
                    ValidUntil = new DateTime(2020, 1, 20)
                },
                new JobOffer
                {
                    Id = 6,
                    CompanyId = 3,
                    JobTitle = "Forklift operator",
                    SalaryFrom = 3500,
                    SalaryTo = 4500,
                    Created = new DateTime(2020, 1, 2),
                    Location = "Radom",
                    Description = "Driving skills required",
                    ValidUntil = new DateTime(2020, 12, 31)
                },
                new JobOffer
                {
                    Id = 7,
                    CompanyId = 4,
                    JobTitle = "Security guard",
                    SalaryFrom = 3000,
                    SalaryTo = 4000,
                    Created = new DateTime(2020, 1, 2),
                    Location = "Lublin",
                    Description = "Karate and judo skills required. Gun license required",
                    ValidUntil = new DateTime(2020, 3, 1)
                }
            );
            modelBuilder.Entity<JobApplication>().HasData(
                new JobApplication
                {
                    Id = 1,
                    JobOfferId = 1,
                    FirstName = "Arkadiusz",
                    LastName = "Górecki",
                    PhoneNumber = "731327437",
                    EmailAddress = "goreckia@gmail.com",
                    ContactAgreement = true,
                    CvUrl = "https://www.cv.com/goreckia/"
                },
                new JobApplication
                {
                    Id = 2,
                    JobOfferId = 1,
                    FirstName = "Maciej",
                    LastName = "Cesarski",
                    PhoneNumber = "123123123",
                    EmailAddress = "cesarskim@gmail.com",
                    ContactAgreement = false,
                    CvUrl = "https://www.cv.com/cesarskim/"
                },
                new JobApplication
                {
                    Id = 3,
                    JobOfferId = 1,
                    FirstName = "Scarlett",
                    LastName = "Johanson",
                    PhoneNumber = "420690000",
                    EmailAddress = "johansons@gmail.com",
                    ContactAgreement = true,
                    CvUrl = "https://www.cv.com/johansons/"
                },
                new JobApplication
                {
                    Id = 4,
                    JobOfferId = 2,
                    FirstName = "Jack",
                    LastName = "Sparrow",
                    PhoneNumber = "120690000",
                    EmailAddress = "sparrowj@gmail.com",
                    ContactAgreement = true,
                    CvUrl = "https://www.cv.com/sparrowj/"
                },
                new JobApplication
                {
                    Id = 5,
                    JobOfferId = 2,
                    FirstName = "Will",
                    LastName = "Turner",
                    PhoneNumber = "111333222",
                    EmailAddress = "turnerw@gmail.com",
                    ContactAgreement = true,
                    CvUrl = "https://www.cv.com/turnerw/"
                },
                new JobApplication
                {
                    Id = 6,
                    JobOfferId = 3,
                    FirstName = "Tony",
                    LastName = "Stark",
                    PhoneNumber = "12346789",
                    EmailAddress = "starkt@gmail.com",
                    ContactAgreement = true,
                    CvUrl = "https://www.cv.com/starkt/"
                },
                new JobApplication
                {
                    Id = 7,
                    JobOfferId = 3,
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    PhoneNumber = "789789789",
                    EmailAddress = "bagginsf@gmail.com",
                    ContactAgreement = false,
                    CvUrl = "https://www.cv.com/bagginsf/"
                },
                new JobApplication
                {
                    Id = 8,
                    JobOfferId = 3,
                    FirstName = "Tom",
                    LastName = "Cruise",
                    PhoneNumber = "675435098",
                    EmailAddress = "cruiset@gmail.com",
                    ContactAgreement = true,
                    CvUrl = "https://www.cv.com/cruiset/"
                },
                new JobApplication
                {
                    Id = 9,
                    JobOfferId = 4,
                    FirstName = "Jojo",
                    LastName = "Rabbit",
                    PhoneNumber = "888888888",
                    EmailAddress = "rabbitj@gmail.com",
                    ContactAgreement = true,
                    CvUrl = "https://www.cv.com/rabbitj/"
                },
                new JobApplication
                {
                    Id = 10,
                    JobOfferId = 5,
                    FirstName = "Joseph",
                    LastName = "Joestar",
                    PhoneNumber = "123890456",
                    EmailAddress = "joestarj@gmail.com",
                    ContactAgreement = false,
                    CvUrl = "https://www.cv.com/joestarj/"
                }
            );
        }
    }
}
