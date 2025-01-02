using Application.Applicants.Mappers;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Applicants.Commands
{
	public class PostApplicantRequestCommand : IRequest<ApplicantDto>
	{
		public string NationalId { get; set; }
		public string HomeAddress { get; set; }
		public string HomeCity { get; set; }
		public string PhoneNumber { get; set; }
		public string? LandLine { get; set; }
	}

	public class PostApplicantRequestCommandHandler : IRequestHandler<PostApplicantRequestCommand, ApplicantDto>
	{
		private readonly IApplicationDbContext _applicationDbContext;

		public PostApplicantRequestCommandHandler(IApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
		}

		public async Task<ApplicantDto> Handle(PostApplicantRequestCommand command, CancellationToken cancellationToken)
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command), "Command cannot be null.");
			}

			var applicant = ApplicantMapper.MapToApplicant(command);

			if (_applicationDbContext == null)
			{
				throw new InvalidOperationException("DbContext is not initialized.");
			}

			await _applicationDbContext.Applicants.AddAsync(applicant, cancellationToken);
			await _applicationDbContext.SaveChangesAsync(cancellationToken);
			var applicantDto = ApplicantMapper.MapToApplicantDto(applicant);

			return applicantDto;
		}
	}
}
