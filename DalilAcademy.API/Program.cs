
using System.Text;
using DalilAcademy.API.Middleware;
using DalilAcademy.Core.Repository;
using DalilAcademy.Core.Service;
using DalilAcademy.Core.Validators;
using DalilAcademy.Infra;
using DalilAcademy.Infra.Repository;
using DalilAcademy.Infra.Service;
using Microsoft.EntityFrameworkCore;
using DalilAcademy.Infra.Data;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserRepository,UserRepository>();
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

var jwt = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
        ClockSkew = TimeSpan.FromMinutes(1)
    });

builder.Services.AddAuthorization();

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

