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
	}
}
