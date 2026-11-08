using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;

namespace DalilAcademy.Core.Mappings;

public static class StudentMapping
{
    public static ResponseStudentDto ToDto(this Student student)
    {
        return new ResponseStudentDto
            (student.Id, student.FullName, student.Email, student.Phone ?? "")
               ;
    }

    public static Student ToEntity(this CreateStudentDto dto)
    {
        return new Student
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone
        };
    }

    public static Student ToFullEntity(this UpdateStudentDto dto, int id)
    {
        return new Student
        {
            Id = id,
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone
        };
    }
}