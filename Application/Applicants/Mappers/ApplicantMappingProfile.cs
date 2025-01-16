using Application.Applicants.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Applicants.Mappers
{
	public class ApplicantMappingProfile : Profile
	{
		public ApplicantMappingProfile()
		{
			// Map from Command to Entity
			CreateMap<PostApplicantRequestCommand, Applicant>()
				.ForMember(dest => dest.ApplicantId, opt => opt.Ignore()) // ID is generated manually
				.ForMember(dest => dest.ApplicantId, opt => opt.MapFrom(_ => Guid.NewGuid()));

			// Map from Entity to DTO
			CreateMap<Applicant, ApplicantDto>();

			// Map from Command to Entity (for Update)
			CreateMap<UpdateApplicantRequestCommand, Applicant>()
				.ForMember(dest => dest.ApplicantId, opt => opt.Ignore()); // ID is not updated
		}
	}
}
