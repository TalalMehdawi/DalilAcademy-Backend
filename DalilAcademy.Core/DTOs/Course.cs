namespace DalilAcademy.Core.DTOs;

public record CreateCourseDto(string Title, Decimal Price, int InstructorId,string? ImageUrl);

public record ResponseCourseDto(int Id, string Title, Decimal Price, string? InstructorName,string? ImageUrl);

public record UpdateCourseDto(string Title, Decimal Price,string? ImageUrl);