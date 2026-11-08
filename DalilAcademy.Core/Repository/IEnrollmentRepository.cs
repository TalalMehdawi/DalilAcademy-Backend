using System;

using DalilAcademy.Core.Entities;

namespace DalilAcademy.Core.Repository;

public interface IEnrollmentRepository
{

    public Task<List<Enrollment>> GetByCourseId(int courseId);
    public Task<List<Enrollment>> GetByStudentId(int studentId);
    public Task<Enrollment> Create(Enrollment enrollment);
    public Task<bool> Delete(int courseId, int studentId);
    public Task<bool> ExistsAsync(int studentId, int courseId);


}