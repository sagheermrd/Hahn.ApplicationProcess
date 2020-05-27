
namespace Hahn.ApplicatonProcess.May2020.Data.Services
{
    using System.Threading.Tasks;
    using Domain.Entities;
    using Models;

    public interface IApplicantService
    {
        Task<ResponseModel> ListAsync();
        Task<ResponseModel> ListByIdAsync(int Id);
        Task<ResponseModel> SaveAsync(Applicant applicant);
        Task<ResponseModel> UpdateAsync(Applicant applicant);
        Task<ResponseModel> DeleteAsync(int id);
    }
}
