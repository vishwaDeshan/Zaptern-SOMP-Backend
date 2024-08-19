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
	public class Administrator :AuditableEntity
	{
		[Key]
		public Guid AdminID { get; set; }
		public string Position { get; set; }
		public string Department { get; set; }

		[ForeignKey("UserID")]
		public Guid UserID { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}

}
