using Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.HealthRecords.Commands
{
	public class PostHealthRecordsRequestCommand : IRequest<HealthRecordsDto>
	{
		public Guid ApplicantId { get; set; }

		public bool? MedicalConditions { get; set; }

		public string? MedicalConditionsDetails { get; set; }

		public bool? Medications { get; set; }

		public string? MedicationsDetails { get; set; }

		public bool? Allergies { get; set; }

		public string? AllergiesDetails { get; set; }

		public bool? Vaccinated { get; set; }

		public string? VaccinatedDetails { get; set; }

		public bool? Surgeries { get; set; }

		public string? SurgeriesDetails { get; set; }

		public bool? Accommodations { get; set; }

		public string? AccommodationsDetails { get; set; }
	}

	public class PostHealthRecordsRequestCommandHandler : IRequestHandler<PostHealthRecordsRequestCommand, HealthRecordsDto>
	{
		private readonly IApplicationDbContext _applicationDbContext;
		private readonly IMapper _mapper;
		public PostHealthRecordsRequestCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
		{
			_applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
			_mapper = mapper;
		}
		public async Task<HealthRecordsDto> Handle(PostHealthRecordsRequestCommand request, CancellationToken cancellationToken)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(request);
				ArgumentNullException.ThrowIfNull(_applicationDbContext, nameof(_applicationDbContext));

				var existngHealthRecord = await _applicationDbContext.ApplicantHealthRecords
				   .FirstOrDefaultAsync(e => e.ApplicantId == request.ApplicantId, cancellationToken);

				var existingApplicant = await _applicationDbContext.Applicants
								   .FirstOrDefaultAsync(e => e.ApplicantId == request.ApplicantId, cancellationToken);

				if (existingApplicant == null)
				{
					throw new ArgumentException(nameof(request.ApplicantId), "ApplicantId cannot be found");
				}

				var healthRecord = _mapper.Map<ApplicantHealthRecords>(request);
				healthRecord.Applicant = existingApplicant;

				if (existngHealthRecord == null)
				{
					await _applicationDbContext.ApplicantHealthRecords.AddAsync(healthRecord, cancellationToken);
				}
				else
				{
					_applicationDbContext.ApplicantHealthRecords.Update(healthRecord);
				}

				await _applicationDbContext.SaveChangesAsync(cancellationToken);
				return _mapper.Map<HealthRecordsDto>(healthRecord);

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
