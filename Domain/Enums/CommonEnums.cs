using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
	public enum UserRole
	{
		Student,
		Admin,
		Instructor
	}

	public enum ApplicationType
	{
		Internship,
		Scholarship
	}

	public enum ApplicationStatus
	{
		Submitted,
		UnderReview,
		Accepted,
		Rejected
	}
}
