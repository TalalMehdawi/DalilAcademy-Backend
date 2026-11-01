namespace DalilAcademy.Core.DTOs;

public record CreateStudentDto(string FullName,string Email,string Phone);
public record ResponseStudentDto(int Id,string FullName,string Email,string Phone);
public record UpdateStudentDto(string FullName,string Email,string Phone);