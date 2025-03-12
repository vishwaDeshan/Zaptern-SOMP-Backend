using Application.HealthRecords.Commands;
using FluentValidation;

namespace Application.HealthRecords.Validators
{
	public class PostHealthRecordsRequestCommandValidator : AbstractValidator<PostHealthRecordsRequestCommand>
	{
		public PostHealthRecordsRequestCommandValidator()
		{ 
			RuleFor(x => x.ApplicantId).NotEmpty().WithMessage("ApplicantId is required");
			RuleFor(x => x.MedicalConditions).NotEmpty().WithMessage("MedicalConditions is required");
			RuleFor(x => x.Medications).NotEmpty().WithMessage("Medications is required");
			RuleFor(x => x.Allergies).NotEmpty().WithMessage("Allergies is required");
			RuleFor(x => x.Vaccinated).NotEmpty().WithMessage("Vaccinated is required");
			RuleFor(x => x.Surgeries).NotEmpty().WithMessage("Surgeries is required");
			RuleFor(x => x.Accommodations).NotEmpty().WithMessage("Accommodations is required");
		}

	}
}
