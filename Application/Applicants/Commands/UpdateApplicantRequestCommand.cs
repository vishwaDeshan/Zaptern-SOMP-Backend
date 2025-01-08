using Application.Applicants.Mappers;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applicants.Commands
{
	public class UpdateApplicantRequestCommand : IRequest<ApplicantDto>
	{
		public Guid ApplicantId { get; set; }
		public string NationalId { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string? LandLine { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? MiddleName { get; set; }
		public string Gender { get; set; }
		public string Pronouns { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Email { get; set; }
		public string Nationality { get; set; }
		public string Street { get; set; }
		public string ZipCode { get; set; }
		public string? Hobbies { get; set; }
		public string? OtherHobbies { get; set; }
		public string? AnyComments { get; set; }
	}

	public class UpdateApplicantRequestHandler : IRequestHandler<UpdateApplicantRequestCommand, ApplicantDto>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public UpdateApplicantRequestHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public async Task<ApplicantDto> Handle(UpdateApplicantRequestCommand request, CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request), "Request cannot be null.");

			var applicant = await _applicationDbContext.Applicants
				.Where(a => a.ApplicantId == request.ApplicantId)
				.FirstOrDefaultAsync(cancellationToken);

			if (applicant == null)
				throw new KeyNotFoundException($"Applicant ID {request.ApplicantId} not found.");

			applicant.NationalId = request.NationalId;
			applicant.City = request.City;
			applicant.PhoneNumber = request.PhoneNumber;
			applicant.LandLine = request.LandLine;
			applicant.FirstName = request.FirstName;
			applicant.LastName = request.LastName;
			applicant.MiddleName = request.MiddleName;
			applicant.Gender = request.Gender;
			applicant.Pronouns = request.Pronouns;
			applicant.DateOfBirth = request.DateOfBirth;
			applicant.Email = request.Email;
			applicant.Nationality = request.Nationality;
			applicant.Street = request.Street;
			applicant.ZipCode = request.ZipCode;
			applicant.Hobbies = request.Hobbies;
			applicant.OtherHobbies = request.OtherHobbies;
			applicant.AnyComments = request.AnyComments;


			await _applicationDbContext.SaveChangesAsync(cancellationToken);
			var updatedApplicantDto = ApplicantMapper.MapToApplicantDto(applicant);

			return updatedApplicantDto;
		}
	}

}
