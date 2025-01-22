namespace Application.EducationDetails
{
	public class EducationalDetailsDto
	{
		public Guid ApplicantId { get; set; }
		public string InstituteName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public bool? IsDoing { get; set; }
		public string? Description { get; set; }
	}
}
