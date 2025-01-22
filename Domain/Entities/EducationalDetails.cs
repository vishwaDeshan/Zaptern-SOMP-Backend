using Domain.Common;

namespace Domain.Entities
{
	public class EducationalDetails : AuditableEntity
	{
		public string InstituteName { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public bool? IsDoing { get; set; }

		public string? description { get; set; }
	}
}
