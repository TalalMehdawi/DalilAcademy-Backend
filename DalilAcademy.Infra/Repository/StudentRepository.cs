using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Exceptions;
using DalilAcademy.Core.Repository;
using DalilAcademy.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DalilAcademy.Infra.Repository;

public class StudentRepository(AppDbContext db): IStudentRepository
{
    public async Task<Student> GetById(int id)
    {
        var student = await db.Students.FindAsync(id);
        if (student is null) throw new NotFoundException("student is not found");
        return student;
    }

    public async Task<List<Student>> GetAll()
    {
        return await db.Students.Include(s => s.Enrollments).ToListAsync();
    }

    public async Task<Student> Create(Student student)
    {
        try
        {
            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();
           
        }
        catch (DbUpdateException ex)when (ex.InnerException is PostgresException
                                          {
                                              SqlState: PostgresErrorCodes.UniqueViolation
                                          })
        {
            throw new ConflictException("Student with this Email already exist !");
        }
        return student;

    }

    public async Task<Student> Update(int Id,Student student)
    {
        var existing = await this.GetById(Id);
        
        if (existing is null) throw new NotFoundException("Student is not found !");
        student.Id = Id;
        db.Entry(existing).CurrentValues.SetValues(student);
        await db.SaveChangesAsync();
        return existing;
    }

    public async Task<Student> Delete(int id)
    {
        var student = await this.GetById(id);
        if (student is null)
        {
            throw new NotFoundException("Student is not found");
         
        }

        db.Students.Remove(student);
        await db.SaveChangesAsync();
        return student;
    }
}