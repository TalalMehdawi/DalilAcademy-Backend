using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Repository;
using DalilAcademy.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace DalilAcademy.Infra.Repository;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await db.Users.AsNoTracking().FirstOrDefaultAsync(u=>u.Email==email);
    }
}