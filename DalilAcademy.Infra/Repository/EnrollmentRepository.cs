using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Repository;
using DalilAcademy.Infra.Data;

using Microsoft.EntityFrameworkCore;
namespace DalilAcademy.Infra.Repository;

public class EnrollmentRepository(AppDbContext db) : IEnrollmentRepository
{

    public async Task<List<Enrollment>> GetByCourseId(int courseId)
    {
        return await db.Enrollments.AsNoTracking()
        .Where(e => e.CourseId == courseId).Include(e => e.Student).Include(e => e.Course).ToListAsync();
    }
    public async Task<List<Enrollment>> GetByStudentId(int studentId)
    {
        return await db.Enrollments.AsNoTracking().Where(e => e.StudentId == studentId)
        .Include(e => e.Student).Include(e => e.Course).ToListAsync();

    }
    public async Task<Enrollment> Create(Enrollment enrollment)
    {
        var createdEnrollment = await db.Enrollments.AddAsync(enrollment);
        await db.SaveChangesAsync();
        return createdEnrollment.Entity;
    }
    public async Task<bool> Delete(int courseId, int studentId)
    {
        var enrollmentToDelete = await db.Enrollments.
        FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);

        if (enrollmentToDelete is null)
            return false;
        db.Enrollments.Remove(enrollmentToDelete);
        await db.SaveChangesAsync();
        return true;
    }

    public Task<bool> ExistsAsync(int studentId, int courseId)
    {
        return db.Enrollments
            .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
    }

}