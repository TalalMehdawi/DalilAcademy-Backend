using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Exceptions;
using DalilAcademy.Core.Repository;
using DalilAcademy.Core.Security;
using DalilAcademy.Core.Service;

namespace DalilAcademy.Infra.Service;

public class AuthService(
    IUserRepository userRepository, 
    IPasswordHasher passwordHasher,
    ITokenService tokenService) : IAuthService
{
   public async Task<LoginResponseDto> Login(LoginRequsetDto dto)
   {
       var user = await userRepository.GetUserByEmail(dto.Email);
       
       if(user is null ||!passwordHasher.Verify(dto.Password,user.PasswordHash))
        throw new UnauthorizedAccessException("Invalid Email or Password");
       var token = tokenService.CreateToken(user);
       return token;

   }

}