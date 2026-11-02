using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Mappings;
using DalilAcademy.Core.Repository;
using FluentValidation;
namespace DalilAcademy.Infra.Service;
using DalilAcademy.Core.Service;

public class StudentService(IStudentRepository studentRepository,
    IValidator<CreateStudentDto> createValidator,
    IValidator<UpdateStudentDto> updateValidator) : IStudentService
{

    public async Task<ResponseStudentDto> GetById(int id)
    {
        var student = await studentRepository.GetById(id);
        return student.ToDto();

    }

    public async Task<List<ResponseStudentDto>> GetAll()
    {
        var students = await studentRepository.GetAll();
        return students.Select(s => s.ToDto()).ToList();
    }

    public async Task<ResponseStudentDto> Create(CreateStudentDto student)
    {
       await createValidator.ValidateAndThrowAsync(student);
       var createdStudent= await studentRepository.Create(student.ToEntity());
       return createdStudent.ToDto();
    }

    public async Task<ResponseStudentDto> Update(int id, UpdateStudentDto student)
    {
       await  updateValidator.ValidateAndThrowAsync(student);
      var updatedStudent=  await studentRepository.Update(id, student.ToFullEntity(id));
      return updatedStudent.ToDto();
    }

    public async Task<ResponseStudentDto> Delete(int id)
    {
        
        var student = await studentRepository.Delete(id);
        return student.ToDto();
        
    }

}