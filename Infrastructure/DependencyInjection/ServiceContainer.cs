using Application;
using Application.Common.Interfaces;
using Application.Post.Queries;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{

			// add database context services
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("Default"),
					b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
				), ServiceLifetime.Scoped);


			// add layer dependency
			services.AddApplicationServices();

			// add authentication services
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = configuration["Jwt:Issuer"],
					ValidAudience = configuration["Jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
				};
			});
			services.AddScoped<IUser, UserRepository>();
			services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
			services.AddScoped<IApplicationDbContext>(provider => (IApplicationDbContext)provider.GetService<AppDbContext>());
			services.AddHttpContextAccessor();

			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetPostRequestHandler).Assembly));

			return services;
		}
	}
}
