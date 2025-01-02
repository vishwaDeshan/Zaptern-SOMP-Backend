namespace Application.Applicants
{
	public class ApplicantDto
	{
		public Guid ApplicantId { get; set; }

		public string NationalId { get; set; }

		public string HomeAddress { get; set; }

		public string HomeCity { get; set; }

		public string PhoneNumber { get; set; }

		public string? LandLine { get; set; }
	}
}
