using Domain.Common;

namespace Domain.Entities
{
	public class PostContent : AuditableEntity
	{
		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public string Author { get; set; } = string.Empty;
    }
}
