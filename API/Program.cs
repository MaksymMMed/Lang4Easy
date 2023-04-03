using API.Middleware;
using BLL.Services.Interfaces;
using BLL.Services.Realizations;
using DAL;
using DAL.Repo.Interfaces;
using DAL.Repo.Realizations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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

//Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Transient fields for repos and services
builder.Services.AddTransient<ILessonRepository, LessonRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IGrammarExerciseRepository, GrammarExerciseRepository>();
builder.Services.AddTransient<ICompleteStatusRepository, CompleteStatusRepository>();

builder.Services.AddTransient<ILessonService, LessonService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IGrammarExerciseService, GrammarExerciseService>();

//Singletone for token service
builder.Services.AddSingleton<ITokenService,TokenService>();

//Security
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TokenMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
