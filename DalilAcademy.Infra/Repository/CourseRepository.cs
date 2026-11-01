using DalilAcademy.Core.Exceptions;
using DalilAcademy.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using DalilAcademy.Core.Repository;
using DalilAcademy.Core.Entities;

namespace DalilAcademy.Infra.Repository;
public class CourseRepository(AppDbContext db) : ICourseRepository
{
   //static readonly List <Course> courses=new List<Course> ();

   public async Task<List<Course>> GetAll()
   {
      var listOfCourses=await db.Courses.Include(c=>c.Instructor).ToListAsync();
      return listOfCourses;
   }

   public async Task<Course?> GetById(int id)
   {
      var course= await db.Courses.Include(c=>c.Instructor).FirstOrDefaultAsync(c=>c.Id==id);
      if (course is null) throw new NotFoundException("course is not found");
      return course;
   }

   public async Task<Course> Create(Course course)
   {
      try
      {
         await db.Courses.AddAsync(course);
         await db.SaveChangesAsync();
         await db.Entry(course).Reference(c => c.Instructor).LoadAsync();
      }
      catch (DbUpdateException ex)when (ex.InnerException is PostgresException
                                        {
                                           SqlState: PostgresErrorCodes.UniqueViolation
                                        })
      {
         throw new ConflictException("Course with this Title already exist !");
      }
      return course;
   }



   public async Task<Course?> Update(Course course)
   {
      var existing = await this.GetById(course.Id);

      if (existing is null) throw new NotFoundException("Course is not found !");
      
      db.Entry(existing).CurrentValues.SetValues(course);
      await db.SaveChangesAsync();
      return existing;
   }

   public async Task Delete(int id)
   {
      var course = await this.GetById(id);
      if (course is null)
      {
         throw new NotFoundException("Course is not found");
         
      }

      db.Courses.Remove(course);
      await db.SaveChangesAsync();
   }
   
}