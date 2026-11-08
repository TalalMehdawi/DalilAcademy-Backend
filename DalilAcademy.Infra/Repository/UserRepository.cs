using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Exceptions;
using DalilAcademy.Core.Repository;
using DalilAcademy.Infra.Data;

using Microsoft.EntityFrameworkCore;

using Npgsql;

namespace DalilAcademy.Infra.Repository;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> Register(User user)
    {
        try
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException
        {
            SqlState: PostgresErrorCodes.UniqueViolation
        })
        {
            throw new ConflictException("User with this Email already exist !");
        }

        return user;
    }
}