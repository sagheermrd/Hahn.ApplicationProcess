
namespace Hahn.ApplicatonProcess.May2020.Data.Validator
{
    using Domain.Entities;
    using FluentValidation;

    public class ApplicantValidator: AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.FamilyName).MinimumLength(5);
            RuleFor(x => x.Address).MinimumLength(10);
            RuleFor(x => x.Age).InclusiveBetween(20, 60);
            RuleFor(x => x.Hired).NotEmpty();
            RuleFor(x => x.EMailAddress).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex);
        }
    }
}
