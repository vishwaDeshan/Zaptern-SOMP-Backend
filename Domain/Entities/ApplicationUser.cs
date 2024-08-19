using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
	public class ApplicationUser : AuditableEntity
	{
		public Guid UserID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public UserRole Role { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public Student Student { get; set; }
		public Administrator Administrator { get; set; }
		public Instructor Instructor { get; set; }
	}
}
