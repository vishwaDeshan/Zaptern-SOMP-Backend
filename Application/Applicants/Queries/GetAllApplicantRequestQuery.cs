using Application.Common;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Applicants.Queries
{
	public class GetAllApplicantRequestQuery : IRequest<List<ApplicantDto>> { }

	public class GetAllApplicantRequestHandler : IRequestHandler<GetAllApplicantRequestQuery, List<ApplicantDto>>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public GetAllApplicantRequestHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<List<ApplicantDto>> Handle(GetAllApplicantRequestQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var applicants = await _applicationDbContext.Applicants.Select(a => new ApplicantDto
				{
					ApplicantId = a.ApplicantId,
					PhoneNumber = a.PhoneNumber,
					HomeAddress = a.HomeAddress,
					HomeCity = a.HomeCity,
					LandLine = a.LandLine,
					NationalId = a.NationalId
				}).ToListAsync(cancellationToken: cancellationToken);

				if (!applicants.Any())
				{
					throw new NotFoundException("Applicant");
				}

				return applicants;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
