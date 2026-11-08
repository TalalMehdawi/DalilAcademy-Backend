using System;


namespace DalilAcademy.Core.Service;

public interface IEnrollmentService
{

    public Task<List<EnrollmentDto>> GetByCourseId(int courseId);
    public Task<List<EnrollmentDto>> GetByStudentId(int studentId);
    public Task<EnrollmentDto> Create(EnrollStudentDto enrollment);
    public Task Delete(int courseId, int studentId);

}