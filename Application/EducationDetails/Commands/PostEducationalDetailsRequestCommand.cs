using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.EducationDetails.Mappers;

namespace Application.EducationDetails.Commands
{
	public class PostEducationalDetailsRequestCommand : IRequest<EducationalDetailsDto>
	{
		public Guid? ApplicantId { get; set; }
		public string InstituteName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public bool? IsDoing { get; set; }
		public string? Description { get; set; }
	}

	public class PostEducationalDetailsRequestHandler : IRequestHandler<PostEducationalDetailsRequestCommand, EducationalDetailsDto>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public PostEducationalDetailsRequestHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
		}

		public async Task<EducationalDetailsDto> Handle(PostEducationalDetailsRequestCommand request, CancellationToken cancellationToken)
		{
			try
			{
				if (request.ApplicantId == null)
				{
					throw new ArgumentNullException(nameof(request.ApplicantId), "ApplicantId cannot be null");
				}

				var existingApplicant = await _applicationDbContext.Applicants
				   .FirstOrDefaultAsync(e => e.ApplicantId == request.ApplicantId, cancellationToken);

				if (existingApplicant == null)
				{
					throw new ArgumentException(nameof(request.ApplicantId), "ApplicantId cannot be found");
				}
					var newEducationalRecord = EducationDetailsMapper.MapToEducationalDetails(request, existingApplicant);
					await _applicationDbContext.EducationalDetails.AddAsync(newEducationalRecord, cancellationToken);
					await _applicationDbContext.SaveChangesAsync(cancellationToken);

					return EducationDetailsMapper.MapToEducationalDetailsDto(newEducationalRecord);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
