using Application.Applicants.Commands;
using Application.EducationDetails.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.EducationDetails.Mappers
{
	public class EducationalDetailsMappingProfile : Profile
	{
		public EducationalDetailsMappingProfile()
		{
			CreateMap<PostEducationalDetailsRequestCommand, EducationalDetails>()
				.ForMember(dest => dest.Applicant, opt => opt.Ignore());
			CreateMap<EducationalDetails, EducationalDetailsDto>();
		}
	}
}