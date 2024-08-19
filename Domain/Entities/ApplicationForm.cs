using Domain.Enums;
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
	public class ApplicationForm : AuditableEntity
	{
		[Key]
		public Guid ApplicationID { get; set; }
		public ApplicationType Type { get; set; }
		public ApplicationStatus Status { get; set; }
		public DateTime SubmissionDate { get; set; }
		public DateTime? ReviewedAt { get; set; }

		[ForeignKey("StudentID")]
		public Guid StudentID { get; set; }
		public Student Student { get; set; }

		[ForeignKey("InternshipID")]
		public Guid? InternshipID { get; set; }
		public Internship Internship { get; set; }

		[ForeignKey("ScholarshipID")]
		public Guid? ScholarshipID { get; set; }
		public Scholarship Scholarship { get; set; }

		[ForeignKey("ReviewedByAdminID")]
		public Guid? ReviewedByAdminID { get; set; }
		public Administrator ReviewedByAdmin { get; set; }
	}
}
