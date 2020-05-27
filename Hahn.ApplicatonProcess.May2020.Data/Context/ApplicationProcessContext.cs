using System;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.May2020.Data.Context
{
    public class ApplicationProcessContext : DbContext
    {
        public ApplicationProcessContext(DbContextOptions<ApplicationProcessContext> options) : base(options) { }

        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            
            builder.Entity<Applicant>().Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Entity<Applicant>().Property(x => x.Hired).HasDefaultValue(value:false);

            builder.Entity<Applicant>().HasData(
                    new Applicant {
                        ID = 1,
                        Name = "David",
                        Address = "London",
                        EMailAddress = "David@emial.com",
                        CountryOfOrigin = "Uk",
                        Age = 25,
                        FamilyName = "Macl",
                    },
                    new Applicant
                    {
                        ID = 2,
                        Name = "Jams",
                        Address = "London",
                        EMailAddress = "jams@emial.com",
                        CountryOfOrigin = "Uk",
                        Age = 30,
                        FamilyName = "bond",
                    },
                    new Applicant
                    {
                        ID = 3,
                        Name = "Liam",
                        Address = "Berlin",
                        EMailAddress = "liam@emial.com",
                        CountryOfOrigin = "Germany",
                        Age = 26,
                        FamilyName = "Burn",
                    },
                    new Applicant
                    {
                        ID = 4,
                        Name = "Michle",
                        Address = "Liverpool",
                        EMailAddress = "mich@emial.com",
                        CountryOfOrigin = "Uk",
                        Age = 28,
                        FamilyName = "Todd",
                    }
                    );

            base.OnModelCreating(builder);
        }
    }
}
