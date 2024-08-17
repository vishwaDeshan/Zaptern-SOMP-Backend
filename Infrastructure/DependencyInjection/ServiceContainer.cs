using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
	public static class ServiceContainer
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("Default"),
					b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
				), ServiceLifetime.Scoped);

			return services;
		}
	}
}
