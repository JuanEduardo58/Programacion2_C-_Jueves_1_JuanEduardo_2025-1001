using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Repositories;
using task_2.Application.Contract;
using task_2.Application.Services;
using task_2.Data; 

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();


builder.Services.AddScoped<ICourseService, CourseService>();
app.Run();