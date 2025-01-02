using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Applicant : AuditableEntity
	{
		public Guid ApplicantId { get; set; }

		public string NationalId { get; set; }

		public string HomeAddress { get; set; }

		public string HomeCity { get; set; }

		public string PhoneNumber { get; set; }

		public string? LandLine { get; set; }

	}
}
