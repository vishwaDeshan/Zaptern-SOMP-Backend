using Application.Applicants.Commands;
using Application.Utilities;
using Domain.Entities;

namespace Application.Applicants.Mappers
{
	public static class ApplicantMapper
	{
		public static Applicant MapToApplicant(PostApplicantRequestCommand command)
		{
			return new Applicant
			{
				ApplicantId = new GuidGenerator().GenerateUniqueId(),
				NationalId = command.NationalId,
				HomeAddress = command.HomeAddress,
				HomeCity = command.HomeCity,
				PhoneNumber = command.PhoneNumber,
				LandLine = command.LandLine
			};
		}

		public static ApplicantDto MapToApplicantDto(Applicant applicant)
		{
			return new ApplicantDto
			{
				NationalId = applicant.NationalId,
				HomeAddress = applicant.HomeAddress,
				HomeCity = applicant.HomeCity,
				PhoneNumber = applicant.PhoneNumber,
				LandLine = applicant.LandLine
			};
		}


	}

}
