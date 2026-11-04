using DalilAcademy.Core.Exceptions;
using DalilAcademy.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using DalilAcademy.Core.Repository;
using DalilAcademy.Core.Entities;
using DalilAcademy.Core.DTOs;

namespace DalilAcademy.Infra.Repository;
public class CourseRepository(AppDbContext db) : ICourseRepository
{
   //static readonly List <Course> courses=new List<Course> ();

   public async Task<PageResulte<ResponseCourseDto>> GetAll(decimal? minPrice, decimal? maxPrice, int page, int pageSize)
{
    var query = db.Courses.AsNoTracking();

    if (minPrice.HasValue)
        query = query.Where(c => c.Price >= minPrice.Value);

    if (maxPrice.HasValue)
        query = query.Where(c => c.Price <= maxPrice.Value);

    int totalCountOfCourses = await query.CountAsync();

    var listOfCourses = await query
        .OrderBy(c => c.Id)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Select(c => new ResponseCourseDto(c.Id, c.Title, c.Price, c.Instructor!.FullName))
        .ToListAsync();

    return new PageResulte<ResponseCourseDto>(listOfCourses, page, pageSize, totalCountOfCourses);
}


   public async Task<int> Count()
   {
      return await db.Courses.CountAsync();
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