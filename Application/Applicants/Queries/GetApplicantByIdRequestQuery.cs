using MediatR;
using Dapper;
using Application.Applicants.Mappers;
using System.Data;
using Domain.Entities;

namespace Application.Applicants.Queries
{
	public class GetApplicantByIdRequestQuery : IRequest<ApplicantDto>
	{
		public Guid Id { get; set; }
	}

	public class GetApplicantByIdRequestHandler : IRequestHandler<GetApplicantByIdRequestQuery, ApplicantDto>
	{
		private readonly IDbConnection _dbConnection;

		public GetApplicantByIdRequestHandler(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}


		public async Task<ApplicantDto> Handle(GetApplicantByIdRequestQuery request, CancellationToken cancellationToken)
		{
			try
			{
				string query = "SELECT * FROM Applicants WHERE ApplicantId = @Id";

				var applicant = await _dbConnection.QueryFirstOrDefaultAsync<Applicant>(
									query, new { Id = request.Id });
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
