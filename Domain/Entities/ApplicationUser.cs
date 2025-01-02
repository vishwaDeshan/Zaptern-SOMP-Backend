using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
	public class ApplicationUser : AuditableEntity
	{
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public UserRole Role { get; set; }

	}
}
