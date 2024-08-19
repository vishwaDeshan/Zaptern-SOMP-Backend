using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<ApplicationUser> Users { get; set; }
		DbSet<Student> Students { get; set; }
		DbSet<Administrator> Administrators { get; set; }
		DbSet<Instructor> Instructors { get; set; }
		DbSet<PostContent> Posts { get; set; }
		DbSet<Feedback> Feedbacks { get; set; }
		DbSet<Course> Courses { get; set; }
		DbSet<Notification> Notifications { get; set; }
		DbSet<Internship> Internships { get; set; }
		DbSet<Scholarship> Scholarships { get; set; }
		DbSet<ApplicationForm> ApplicationForms { get; set; }


	}
}
