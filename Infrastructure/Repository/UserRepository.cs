using Application.Common.Interfaces;
using Application.UserAccount.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
	public class UserRepository : IUser
	{
		private readonly AppDbContext _context;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;

		public UserRepository(AppDbContext appDbContext, IJwtTokenGenerator jwtTokenGenerator)
		{
			_context = appDbContext;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

		private async Task<ApplicationUser> findUserByEmail(string email)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
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
				return new LoginResponse(true, "Login Successfully", _jwtTokenGenerator.GenerateToken(getUser));
			}
			else
			{
				return new LoginResponse(false, "Invalid Credentials");
			}
		}

		public async Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO)
		{
			var getUser = await findUserByEmail(registerUserDTO.Email!);

			if (getUser != null)
			{
				return new RegistrationResponse(false, "User already exists");
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
