using Domain.Common;
using Domain.Entities;

public class EducationalDetails : AuditableEntity
{
	public required Applicant Applicant { get; set; }
	public string InstituteName { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime? EndDate { get; set; }
	public bool? IsDoing { get; set; }
	public string? Description { get; set; }
}
