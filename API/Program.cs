using BLL.Services.Interfaces;
using BLL.Services.Realizations;
using DAL;
using DAL.Repo.Interfaces;
using DAL.Repo.Realizations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

// App Builder
var builder = WebApplication.CreateBuilder(args);

//Controllers
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.PropertyNamingPolicy = null;
});

//DbContext
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoContext")));

//Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Transient fields
builder.Services.AddTransient<ILessonRepository, LessonRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ILessonService, LessonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
