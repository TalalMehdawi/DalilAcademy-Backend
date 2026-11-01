namespace DalilAcademy.Core.DTOs;

public record CreateCourseDto(string Title, Decimal Price, int InstructorId);

public record ResponseCourseDto(int Id, string Title, Decimal Price, string? InstructorName);

public record UpdateCourseDto(string Title, Decimal Price);
