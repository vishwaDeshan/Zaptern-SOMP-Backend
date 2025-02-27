using Application.HealthRecords.Commands;
using AutoMapper;

namespace Application.HealthRecords.Mappers
{
	public class HealthRecordsMappingProfile : Profile
	{
		public HealthRecordsMappingProfile()
		{
			CreateMap<PostHealthRecordsRequestCommand, ApplicantHealthRecords>()
				.ForMember(dest => dest.Applicant, opt => opt.Ignore());
			CreateMap<ApplicantHealthRecords, HealthRecordsDto>();
		}
	}
}
