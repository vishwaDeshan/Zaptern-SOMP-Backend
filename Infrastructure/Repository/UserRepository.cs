using Application.Contracts;
using Application.UserAccount.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repository
{
    internal class UserRepository : IUser
	{
		private readonly AppDbContext _context;
		private readonly IConfiguration configuration;

		private async Task<ApplicationUser> findUserByEmail(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

		public UserRepository(AppDbContext appDbContext, IConfiguration configuration)
        {
            this._context = appDbContext;
			this.configuration = configuration;
		}
		public async Task<LoginResponse> LoginUserAsync(LoginUserDTO loginUserDTO)
		{
			var getUser = await findUserByEmail(loginUserDTO.Email!);
			if (getUser == null)
			{
				return new LoginResponse(false, "User Not Found");
			}

			bool checkPassword = BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, getUser.Password);

			if (checkPassword)
			{
				return new LoginResponse(true, "Login Successfully", GenerateJWToken(getUser));
			}
			else
			{
				return new LoginResponse(false, "Invalid Credentials");
			}
		}

		private string GenerateJWToken(ApplicationUser user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var userClaims = new[]
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.Name!),
				new Claim(ClaimTypes.Email, user.Email!)
		};
			var token = new JwtSecurityToken(
				issuer: configuration["Jwt:Issuer"],
				audience: configuration["Jwt:Audience"],
				claims: userClaims,
				expires: DateTime.Now.AddDays(5),
				signingCredentials: credentials
				);
			return new JwtSecurityTokenHandler().WriteToken(token);	
		}

		public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
		{
			var getUser = findUserByEmail(registerUserDTO.Email!);

			if(getUser == null)
			{
				return new RegistrationResponse(false, "User already exist");
			}

			_context.Users.Add(new ApplicationUser()
			{
				Name = registerUserDTO.Name,
				Email = registerUserDTO.Email,
				Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
			});
			await _context.SaveChangesAsync();
			return new RegistrationResponse(true, "Registration Completed");
		}
	}
}
