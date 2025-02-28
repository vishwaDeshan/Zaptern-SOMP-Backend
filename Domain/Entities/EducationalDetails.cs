using Domain.Common;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class EducationalDetails : AuditableEntity
{
	[ForeignKey("ApplicantId")]
	public required Applicant Applicant { get; set; }

	public string InstituteName { get; set; }

	public DateTime StartDate { get; set; }
	public DateTime? EndDate { get; set; }
	public bool? IsDoing { get; set; }
	public string? Description { get; set; }
}
