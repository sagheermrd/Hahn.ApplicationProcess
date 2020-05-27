using System;
namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.IRepository;
    using Microsoft.EntityFrameworkCore;
    using Hahn.ApplicatonProcess.May2020.Domain.Entities;

    public class ApplicantRepository: BaseRepository, IApplicantRepository
    {
        public ApplicantRepository(Context.ApplicationProcessContext context) : base(context) { }

        public async Task AddAsync(Applicant applicant)
        {
           await _context.Applicants.AddAsync(applicant);
        }

        public async Task<Applicant> FindByIdAsync(int id)
        {
            return await _context.Applicants.FindAsync(id);
        }

        public async Task<IEnumerable<Applicant>> ListAsync()
        {
            return await _context.Applicants
                        .AsNoTracking()
                        .ToListAsync();
        }

        public void Remove(Applicant applicant)
        {
            _context.Applicants.Remove(applicant);
        }

        public void Update(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
        }
    }
}
