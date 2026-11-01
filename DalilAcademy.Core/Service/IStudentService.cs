using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;

namespace DalilAcademy.Core.Service;

public interface IStudentService
{
    
    public Task<ResponseStudentDto> GetById(int id);

    public Task<List<ResponseStudentDto>> GetAll();

    public Task<ResponseStudentDto> Create(CreateStudentDto student);
    
    public Task<ResponseStudentDto> Update(int id,UpdateStudentDto student);

    public Task<ResponseStudentDto> Delete(int id);
}