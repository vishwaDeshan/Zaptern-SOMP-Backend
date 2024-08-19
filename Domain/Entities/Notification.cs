using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
	public class Notification : AuditableEntity
	{
		[Key]
		public Guid NotificationID { get; set; }
		public string Message { get; set; }
		public bool IsRead { get; set; }
		public DateTime CreatedAt { get; set; }

		[ForeignKey("UserID")]
		public Guid UserID { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
