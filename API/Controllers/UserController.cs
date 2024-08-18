using Application.Common.Interfaces;
using Application.UserAccount.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class User : ControllerBase
	{
		private readonly IUser user;

		public User(IUser user) {
			this.user = user;
		}

		[HttpPost("login")]
		public async Task<ActionResult<LoginResponse>> LogUser(LoginUserDTO loginUserDTO)
		{
			var result =  await user.LoginUserAsync(loginUserDTO);
			return Ok(result);
		}

		[HttpPost("register")]
		public async Task<ActionResult<LoginResponse>> RegisterUser(RegisterUserDTO registerUserDTO)
		{
			var result = await user.RegisterUserAsync(registerUserDTO);
			return Ok(result);
		}

	}
}
