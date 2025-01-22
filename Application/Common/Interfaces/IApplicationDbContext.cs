using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<ApplicationUser> Users { get; set; }

		DbSet<Applicant> Applicants { get; set; }

		DbSet<EducationalDetails> EducationalDetails { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
