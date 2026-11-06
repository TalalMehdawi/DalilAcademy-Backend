namespace DalilAcademy.Core.DTOs;

public record LoginRequsetDto(string Email, string Password);

public record LoginResponseDto(string Token, DateTime ExpiresAt);
