

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Data.Models;
    using Data.Services;
    using Domain.Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService applicantService;

        public ApplicantController(IApplicantService service) {
            applicantService = service;
        }

        [HttpGet]
        public async Task<ResponseModel> Get()
        {

            return await applicantService.ListAsync();
            
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ResponseModel> Get(int id)
        {
            return await applicantService.ListByIdAsync(id);
        }

        // POST: api/Applicant
        [HttpPost]
        public async Task<ResponseModel> Post([FromBody] Applicant applicant)
        {
            return await applicantService.SaveAsync(applicant);
            
        }
    
        // PUT: api/Applicant/5
        [HttpPut("{id}")]
        public async Task<ResponseModel> Put(int id, [FromBody] Applicant applicant)
        {
            applicant.ID = id;
            return await applicantService.UpdateAsync(applicant);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ResponseModel> Delete(int id)
        {
            return await applicantService.DeleteAsync(id);
        }
    }
}
