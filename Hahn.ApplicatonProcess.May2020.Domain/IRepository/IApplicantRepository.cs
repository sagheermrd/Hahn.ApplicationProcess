

namespace Hahn.ApplicatonProcess.May2020.Domain.IRepository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Entities;

    public interface IApplicantRepository
    {
        Task<IEnumerable<Applicant>> ListAsync();
        Task AddAsync(Applicant applicant);
        Task<Applicant> FindByIdAsync(int id);
        void Update(Applicant applicant);
        void Remove(Applicant applicant);
    }
}
