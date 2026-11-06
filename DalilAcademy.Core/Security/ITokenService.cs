using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;

namespace DalilAcademy.Core.Security;

public interface ITokenService
{
    LoginResponseDto CreateToken(User user);

}