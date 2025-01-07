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
					LandLine = a.LandLine,
					NationalId = a.NationalId,
					City = a.City,
					FirstName = a.FirstName,
					LastName = a.LastName,
					Email = a.Email,
					DateOfBirth = a.DateOfBirth,
					Gender = a.Gender,
					MiddleName = a.MiddleName,
					Nationality = a.Nationality,
					Pronouns = a.Pronouns,
					Street = a.Street,
					Hobbies = a.Hobbies,
					ZipCode	= a.ZipCode,
					OtherHobbies = a.OtherHobbies,
					AnyComments = a.AnyComments
				}).ToListAsync(cancellationToken: cancellationToken);

				if (!applicants.Any())
				{
					throw new NotFoundException("Applicants");
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
