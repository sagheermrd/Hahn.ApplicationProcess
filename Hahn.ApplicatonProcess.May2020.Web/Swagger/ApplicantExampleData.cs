
namespace Hahn.ApplicatonProcess.May2020.Web.Swagger
{
    using System;
    using Hahn.ApplicatonProcess.May2020.Domain.Entities;
    using Swashbuckle.AspNetCore.Filters;
    public class ApplicantExampleData: IExamplesProvider<Applicant>
    {
        public ApplicantExampleData()
        {
        }

        public Applicant GetExamples()
        {
            return new Applicant
            {
                ID = 1,
                Name = "David",
                Address = "South London",
                EMailAddress = "David@emial.com",
                CountryOfOrigin = "Uk",
                Age = 25,
                FamilyName = "Maclaugh",
            };
        }
    }
}
