using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.EducationDetails.Queries
{
	public class GetAllEducationalDetailsRequestQuery : IRequest<List<EducationalDetailsDto>> { }

	public class GetAllEducationalRequestQueryHandler : IRequestHandler<GetAllEducationalDetailsRequestQuery, List<EducationalDetailsDto>>
	{

		private readonly IApplicationDbContext _applicationDbContext;

		public GetAllEducationalRequestQueryHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public async Task<List<EducationalDetailsDto>> Handle(GetAllEducationalDetailsRequestQuery request, CancellationToken cancellationToken)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(request);
				ArgumentNullException.ThrowIfNull(_applicationDbContext, nameof(_applicationDbContext));

				var result = await _applicationDbContext.EducationalDetails.Select(a => new EducationalDetailsDto
				{
					ApplicantId = a.Applicant.ApplicantId,
					Description = a.Description,
					EndDate = a.EndDate,
					InstituteName = a.InstituteName,
					StartDate = a.StartDate,
					IsDoing = a.IsDoing
				}).ToListAsync(cancellationToken);

				return result;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
