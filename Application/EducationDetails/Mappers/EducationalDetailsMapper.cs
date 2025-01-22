using Application.EducationDetails.Commands;
using Domain.Entities;

namespace Application.EducationDetails.Mappers
{
	public static class EducationDetailsMapper
	{
		public static EducationalDetails MapToEducationalDetails(PostEducationalDetailsRequestCommand command, Applicant applicant)
		{
			return new EducationalDetails
			{
				Applicant = applicant,
				InstituteName = command.InstituteName,
				Description = command.Description,
				IsDoing = command.IsDoing,
				EndDate = command.EndDate,
				StartDate = command.StartDate,
			};
		}

		public static EducationalDetailsDto MapToEducationalDetailsDto(EducationalDetails educationalDetails)
		{
			return new EducationalDetailsDto
			{
				ApplicantId = educationalDetails.Applicant.ApplicantId,
				InstituteName = educationalDetails.InstituteName,
				Description = educationalDetails.Description,
				StartDate = educationalDetails.StartDate,
				EndDate = educationalDetails.EndDate,
				IsDoing = educationalDetails.IsDoing,
			};
		}

		public static void MapToExistingRecord(PostEducationalDetailsRequestCommand command, EducationalDetails existingRecord)
		{
			existingRecord.InstituteName = command.InstituteName;
			existingRecord.StartDate = command.StartDate;
			existingRecord.EndDate = command.EndDate;
			existingRecord.IsDoing = command.IsDoing;
			existingRecord.Description = command.Description;
		}
	}
}
