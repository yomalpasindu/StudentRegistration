using AutoMapper;
using StudentRegistration.Services.Activities_;
using StudentRegistration.Services.Course_;
using StudentRegistration.Services.Lession_;
using StudentRegistration.Services.Student_;
using StudentRegistration.Services.Teacher_;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.OAuth;
using StudentRegistration.Modles;
using System.Text;
using StudentRegistration.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>
{
    options.Filters.Add<AuthorizationFilter>();
});
//Config the token
builder.Services.AddAuthentication("JWTToken")
    .AddJwtBearer("JWTToken", options =>
    {
        var keyBytes = Encoding.UTF8.GetBytes(AuthConstants.Secret);
        var key = new SymmetricSecurityKey(keyBytes);

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = AuthConstants.Issuer,
            ValidAudience = AuthConstants.Audience,
            IssuerSigningKey = key
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStudentRepository, StudentRegistrationSqlServerService>();
builder.Services.AddTransient<ICoursesRepository, CoursesSqlServerService>();
builder.Services.AddTransient<ITeacherRepository, TeacherSqlServerService>();
builder.Services.AddTransient<ILessionsRepository, LessionsSqlServerService>();
builder.Services.AddTransient<IActivityRepository, ActivitySqlServerService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
