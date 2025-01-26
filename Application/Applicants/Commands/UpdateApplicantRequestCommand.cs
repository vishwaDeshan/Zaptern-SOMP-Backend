using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
		private readonly IMapper _mapper;

		public UpdateApplicantRequestHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
		{
			_applicationDbContext = applicationDbContext;
			_mapper = mapper;
		}

		public async Task<ApplicantDto> Handle(UpdateApplicantRequestCommand request, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(request);
			ArgumentNullException.ThrowIfNull(_applicationDbContext, nameof(_applicationDbContext));

			var applicant = await _applicationDbContext.Applicants
				.Where(a => a.ApplicantId == request.ApplicantId)
				.FirstOrDefaultAsync(cancellationToken);

			if (applicant == null)
				throw new KeyNotFoundException($"Applicant ID {request.ApplicantId} not found.");

			_mapper.Map(request, applicant);

			await _applicationDbContext.SaveChangesAsync(cancellationToken);
			return _mapper.Map<ApplicantDto>(applicant);
		}
	}
}
