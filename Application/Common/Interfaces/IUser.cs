using Application.UserAccount.DTOs;

namespace Application.Common.Interfaces
{
    public interface IUser
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<LoginResponse> LoginUserAsync(LoginUserDTO loginUserDTO);
    }
}
