using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EducationDetails.Queries
{
	public class GetEducationalDetailsByIdRequestQuery : IRequest<List<EducationalDetailsDto>>
	{
		public Guid ApplicantId { get; set; }
	}

	public class GetEducationalDetailsByIdRequestHandler : IRequestHandler<GetEducationalDetailsByIdRequestQuery, List<EducationalDetailsDto>>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public GetEducationalDetailsByIdRequestHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
		}

		public async Task<List<EducationalDetailsDto>> Handle(GetEducationalDetailsByIdRequestQuery request, CancellationToken cancellationToken)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(request);

				var result = await _applicationDbContext.EducationalDetails
					.Where(e => e.Applicant.ApplicantId == request.ApplicantId)
					.Select(e => new EducationalDetailsDto
					{
						ApplicantId = e.Applicant.ApplicantId,
						InstituteName = e.InstituteName,
						StartDate = e.StartDate,
						EndDate = e.EndDate,
						IsDoing = e.IsDoing,
						Description = e.Description
					}).ToListAsync(cancellationToken);

				if (request is null)
				{
					throw new Exception("no results found");
				}

				return result;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
