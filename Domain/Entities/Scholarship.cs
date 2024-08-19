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
	public class Scholarship : AuditableEntity
	{
		[Key]
		public Guid ScholarshipID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Amount { get; set; }
		public string EligibilityCriteria { get; set; }
		public DateTime ApplicationDeadline { get; set; }

		[ForeignKey("PostedByAdminID")]
		public Guid PostedByAdminID { get; set; }
		public Administrator PostedByAdmin { get; set; }

		public ICollection<ApplicationForm> ApplicationForms { get; set; }
	}
}
