
using DalilAcademy.API.Middleware;
using DalilAcademy.Core.Repository;
using DalilAcademy.Core.Service;
using DalilAcademy.Core.Validators;
using DalilAcademy.Infra.Repository;
using DalilAcademy.Infra.Service;
using Microsoft.EntityFrameworkCore;
using DalilAcademy.Infra.Data;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseDtoValidator>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Type = null;
        ctx.ProblemDetails.Extensions.Remove("traceId");
    };
});
builder.Services.AddDbContext <AppDbContext >( opt =>
    opt .UseNpgsql( builder .Configuration. GetConnectionString ("DefaultConnection")));




var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Dalil Academy API");
    });
}

app.UseExceptionHandler();

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();



app.Run();

