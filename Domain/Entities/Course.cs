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
	public class Course : AuditableEntity
	{
		[Key]
		public Guid CourseID { get; set; }
		public string CourseName { get; set; }
		public string CourseCode { get; set; }
		public string Department { get; set; }

		[ForeignKey("InstructorID")]
		public Guid InstructorID { get; set; }
		public Instructor Instructor { get; set; }

		public ICollection<Feedback> Feedbacks { get; set; }
	}
}
