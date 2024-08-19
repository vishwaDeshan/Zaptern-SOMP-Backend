using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Domain.Common;

namespace Domain.Entities
{
	public class Student : AuditableEntity
	{
		[Key]
		public Guid StudentID { get; set; }
		public string EnrollmentNumber { get; set; }
		public string Department { get; set; }
		public int YearOfStudy { get; set; }
		public decimal CGPA { get; set; }

		[ForeignKey("UserID")]
		public Guid UserID { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
