using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Instructor
	{
		[Key]
		public Guid InstructorID { get; set; }
		public string Faculty { get; set; }
		public string Department { get; set; }

		[ForeignKey("UserID")]
		public Guid UserID { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
