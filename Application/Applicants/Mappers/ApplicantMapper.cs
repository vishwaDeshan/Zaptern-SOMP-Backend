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
				City = command.City,
				PhoneNumber = command.PhoneNumber,
				LandLine = command.LandLine,
				Email = command.Email,
				DateOfBirth = command.DateOfBirth,
				FirstName = command.FirstName,
				LastName = command.LastName,
				MiddleName = command.MiddleName,
				Nationality = command.Nationality,
				Pronouns = command.Pronouns,
				Street = command.Street,
				ZipCode = command.ZipCode,
				Hobbies	= command.Hobbies,
				Gender = command.Gender,
				AnyComments = command.AnyComments,
				OtherHobbies = command.OtherHobbies,
			};
		}

		public static ApplicantDto MapToApplicantDto(Applicant applicant)
		{
			return new ApplicantDto
			{
				NationalId = applicant.NationalId,
				PhoneNumber = applicant.PhoneNumber,
				LandLine = applicant.LandLine,
				FirstName= applicant.FirstName,
				LastName= applicant.LastName,
				MiddleName = applicant.MiddleName,
				Pronouns = applicant.Pronouns,
				AnyComments = applicant.AnyComments,
				Hobbies = applicant.Hobbies,
				Nationality = applicant.Nationality,
				Street = applicant.Street,
				ZipCode = applicant.ZipCode,
				City = applicant.City,
				Email = applicant.Email,
				DateOfBirth = applicant.DateOfBirth,
				Gender=applicant.Gender,
				OtherHobbies = applicant.OtherHobbies,
			};
		}


	}

}
