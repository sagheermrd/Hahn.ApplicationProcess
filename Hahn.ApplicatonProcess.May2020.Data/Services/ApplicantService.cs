
namespace Hahn.ApplicatonProcess.May2020.Data.Services
{
    using System;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.IRepository;
    using Models;

    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository applicantRepository;
        private readonly IUnitOfWork unitOfWork;
        public ApplicantService(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork)
        {
            this.applicantRepository = applicantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> DeleteAsync(int id)
        {
            var exisitingApplicant = await applicantRepository.FindByIdAsync(id);
            if (exisitingApplicant == null)
                return new ResponseModel { Success=false,Message="Selected applicant is not exist",Data=null};
            try
            {
                applicantRepository.Remove(exisitingApplicant);
                await unitOfWork.CompleteAsync();

                return new ResponseModel {Success=true,StatusCode=201,Message="Successfully removed selected applicant" };
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ResponseModel {Success=false, Message=$"An error occurred when deleting the applicant: {ex.Message}" };
            }
        }

        public async Task<ResponseModel> ListAsync()
        {
            var applicants = await applicantRepository.ListAsync();
            return new ResponseModel {Success=true,Data=applicants,StatusCode=201 };

        }
        public async Task<ResponseModel> ListByIdAsync(int Id)
        {
            var applicant = await applicantRepository.FindByIdAsync(Id);
            if (applicant == null)
                return new ResponseModel {Success=false,StatusCode=404,Message="No applicant found" };
            return new ResponseModel { Success = true, Data = applicant, StatusCode = 201 };

        }
        public async Task<ResponseModel> SaveAsync(Applicant applicant)
        {
            try
            {

                if (applicant == null)
                    return new ResponseModel { Success=false,Message="Invalid applicant",StatusCode=400};
                var validationResult = new Validator.ApplicantValidator().Validate(applicant);
                if (!validationResult.IsValid)
                    return new ResponseModel { Success = false, Message = validationResult.ToString(" Error:"),StatusCode=400};

                await applicantRepository.AddAsync(applicant);
                await unitOfWork.CompleteAsync();

                return new ResponseModel { Success=true,Message="Successfully added new applicant"};
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ResponseModel { Message = $"An error occurred when saving the applicant: {ex.Message}",Success=false };
            }
        }

        public async Task<ResponseModel> UpdateAsync(Applicant applicant)
        {
            var existingApplicant = await applicantRepository.FindByIdAsync(applicant.ID);

            if (existingApplicant == null)
                return new ResponseModel { Success=false,Message="Applicant not exisit"};

            var validationResult = new Validator.ApplicantValidator().Validate(applicant);
            if (!validationResult.IsValid)
                return new ResponseModel { Success = false, Message = validationResult.ToString(" Error:"), StatusCode = 400 };

            existingApplicant.Name = applicant.Name;
            existingApplicant.Address = applicant.Address;
            existingApplicant.Age = applicant.Age;
            existingApplicant.CountryOfOrigin = applicant.CountryOfOrigin;
            existingApplicant.EMailAddress = applicant.EMailAddress;
            existingApplicant.FamilyName = applicant.FamilyName;
            existingApplicant.Hired = applicant.Hired;

            try
            {
                applicantRepository.Update(existingApplicant);
                await unitOfWork.CompleteAsync();

                return new ResponseModel { Success=true,Message="Applicant updated successfully",Data=applicant, StatusCode=201};
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ResponseModel { Message = $"An error occurred when updating the product: {ex.Message}",Success=false };
            }
        }
    }
}
