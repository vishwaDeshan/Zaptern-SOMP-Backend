using MediatR;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Applicants.Mappers;

namespace Application.Applicants.Queries
{
	public class GetApplicantByIdRequestQuery : IRequest<ApplicantDto>
	{
		public Guid Id { get; set; }
	}

	public class GetApplicantByIdRequestHandler : IRequestHandler<GetApplicantByIdRequestQuery, ApplicantDto>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public GetApplicantByIdRequestHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<ApplicantDto> Handle(GetApplicantByIdRequestQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var applicant = await _applicationDbContext.Applicants
					.Where(a => a.ApplicantId == request.Id)
					.FirstOrDefaultAsync(cancellationToken);

				if (applicant == null)
				{
					throw new Exception($"Applicant with ID {request.Id} not found.");
				}

				var applicantDto = ApplicantMapper.MapToApplicantDto(applicant);

				return applicantDto;
			}
			catch (Exception ex)
			{
				throw new Exception($"An error occurred while retrieving the applicant: {ex.Message}", ex);
			}
		}
	}
}
