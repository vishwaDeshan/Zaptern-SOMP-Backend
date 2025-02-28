using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.HealthRecords.Queries
{
	public class GetHealthRecordsRequestQuery : IRequest<HealthRecordsDto>
	{
		public Guid Id { get; set; }
	}

	public class GetHealthRecordsRequestQueryHandler : IRequestHandler<GetHealthRecordsRequestQuery, HealthRecordsDto>
	{
		private readonly IApplicationDbContext _applicationDbContext;
		public GetHealthRecordsRequestQueryHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}
		public async Task<HealthRecordsDto> Handle(GetHealthRecordsRequestQuery request, CancellationToken cancellationToken)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(request);
				ArgumentNullException.ThrowIfNull(_applicationDbContext, nameof(_applicationDbContext));

				var result = await _applicationDbContext.ApplicantHealthRecords.Where(HealthRecords => HealthRecords.Applicant.ApplicantId == request.Id)
					.Select(HealthRecords => new HealthRecordsDto
					{
						ApplicantId = HealthRecords.Applicant.ApplicantId,
						MedicalConditions = HealthRecords.MedicalConditions,
						MedicalConditionsDetails = HealthRecords.MedicalConditionsDetails,
						Medications = HealthRecords.Medications,
						MedicationsDetails = HealthRecords.MedicationsDetails,
						Allergies = HealthRecords.Allergies,
						AllergiesDetails = HealthRecords.AllergiesDetails,
						Vaccinated = HealthRecords.Vaccinated,
						VaccinatedDetails = HealthRecords.VaccinatedDetails,
						Surgeries = HealthRecords.Surgeries,
						SurgeriesDetails = HealthRecords.SurgeriesDetails,
						Accommodations = HealthRecords.Accommodations,
						AccommodationsDetails = HealthRecords.AccommodationsDetails
					}).FirstOrDefaultAsync(cancellationToken);

				if (result is null)
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
