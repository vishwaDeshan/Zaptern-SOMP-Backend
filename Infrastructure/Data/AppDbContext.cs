using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class AppDbContext : DbContext, IApplicationDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<ApplicationUser> Users { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Administrator> Administrators { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<PostContent> Posts { get; set; }
		public DbSet<Feedback> Feedbacks { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Notification> Notifications { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ApplicationUser>()
				.HasOne(u => u.Student)
				.WithOne(s => s.ApplicationUser)
				.HasForeignKey<Student>(s => s.UserID);

			modelBuilder.Entity<ApplicationUser>()
				.HasOne(u => u.Administrator)
				.WithOne(a => a.ApplicationUser)
				.HasForeignKey<Administrator>(a => a.UserID);

			modelBuilder.Entity<ApplicationUser>()
				.HasOne(u => u.Instructor)
				.WithOne(i => i.ApplicationUser)
				.HasForeignKey<Instructor>(i => i.UserID);

			modelBuilder.Entity<Feedback>()
				.HasOne(f => f.Student)
				.WithMany()
				.HasForeignKey(f => f.StudentID)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Feedback>()
				.HasOne(f => f.Course)
				.WithMany(c => c.Feedbacks)
				.HasForeignKey(f => f.CourseID)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
