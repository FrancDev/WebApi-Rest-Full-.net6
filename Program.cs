using Microsoft.EntityFrameworkCore;
using webapi_Francisco_1033769977.Models;
using webapi_Francisco_1033769977.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 //dependency injection for each services
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<INotesService, NotesService>();
builder.Services.AddScoped<IStudentsService, StudentsServices>();
builder.Services.AddScoped<ITeachersServices, TeachersServices>();

builder.Services.AddSqlServer<SchoolContext> ("Data Source=CISCO\\SQLEXPRESS;Initial Catalog=Db_Franc_1033769977;user id=User_Franc;password=1qw23er4;TrustServerCertificate=True");

var app = builder.Build();

app.MapGet("/dbConecction", async ([FromServices] SchoolContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Data Base In Memory" + dbContext.Database.IsInMemory());
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();



