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
            base.OnModelCreating(builder);
        }
    }
}
