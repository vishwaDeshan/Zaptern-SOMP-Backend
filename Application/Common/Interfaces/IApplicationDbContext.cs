using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<ApplicationUser> Users { get; set; }

		DbSet<PostContent> Posts { get; set; }
	}
}
