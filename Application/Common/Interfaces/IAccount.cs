using Application.UserAccount.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAccount
    {
        Task<RegistrationResponse> RegisterAccountAsync(RegisterUserDTO model);
        Task<LoginResponse> LogInAccountAsync(LoginUserDTO model);
    }
}
