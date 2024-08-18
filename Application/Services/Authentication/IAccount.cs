using Application.UserAccount.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication
{
    public  interface IAccount
	{
		Task<RegistrationResponse> RegisterAccountAsync(RegisterUserDTO model);
		Task<LoginResponse> LogInAccountAsync(LoginUserDTO model);
	}
}
