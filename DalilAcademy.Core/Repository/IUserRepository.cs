using DalilAcademy.Core.Entities;

namespace DalilAcademy.Core.Repository;

public interface IUserRepository
{
    public Task<User?> GetUserByEmail(string email);
}