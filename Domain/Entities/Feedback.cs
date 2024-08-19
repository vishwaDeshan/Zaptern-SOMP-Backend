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
	public class Feedback : AuditableEntity
	{
		[Key]
		public Guid FeedbackID { get; set; }
		public int Rating { get; set; }
		public string Comment { get; set; }
		public DateTime SubmittedAt { get; set; }

		[ForeignKey("StudentID")]
		public Guid StudentID { get; set; }
		public Student Student { get; set; }

		[ForeignKey("CourseID")]
		public Guid CourseID { get; set; }
		public Course Course { get; set; }
	}

}
