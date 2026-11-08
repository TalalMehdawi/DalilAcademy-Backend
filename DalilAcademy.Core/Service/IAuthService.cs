using DalilAcademy.Core.DTOs;

namespace DalilAcademy.Core.Service;

public interface IAuthService
{
    Task<LoginResponseDto> Login(LoginRequsetDto dto);
    Task<LoginResponseDto> Register(RegisterRequsetDto dto);


}