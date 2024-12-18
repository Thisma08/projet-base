using System.Text;
using Application.v1.Cores.Themes.Commands;
using Application.v1.Cores.Themes.Commands.Create;
using Application.v1.Cores.Themes.Commands.Delete;
using Application.v1.Cores.Themes.Commands.Update;
using Application.v1.Cores.Themes.Queries;
using Application.v1.Cores.Themes.Queries.GetAll;
using Application.v1.Cores.Users.Commands;
using Application.v1.Cores.Users.Commands.Create;
using Application.v1.Cores.Users.Commands.Delete;
using Application.v1.Cores.Users.Commands.Login;
using Application.v1.Cores.Users.Commands.Update;
using Application.v1.Cores.Users.Query;
using Application.v1.Cores.Users.Query.GetAll;
using Application.v1.Cores.Users.Query.GetById;
using Application.v1.Features.Questions.Commands;
using Application.v1.Features.Questions.Commands.Create;
using Application.v1.Features.Questions.Commands.Delete;
using Application.v1.Features.Questions.Commands.Update;
using Application.v1.Features.Quizzes.Commands;
using Application.v1.Features.Quizzes.Commands.Create;
using Application.v1.Features.Quizzes.Commands.Delete;
using Application.v1.Features.Quizzes.Commands.Update;
using Application.v1.Features.Quizzes.Query;
using Application.v1.Features.Quizzes.Query.GetAll;
using Application.v1.Features.Quizzes.Query.GetById;
using Application.v1.Features.Scores.Commands;
using Application.v1.Features.Scores.Commands.Create;
using Application.v1.Features.Scores.Queries;
using Application.v1.Features.Scores.Queries.GetAll;
using Application.v1.Features.Scores.Queries.GetById;
using Application.v1.Features.Scores.Queries.GetByQuizzId;
using Application.v1.Features.Scores.Queries.GetByUserId;
using Application.v1.Shared.Token;
using Infrastructure.EF;
using Infrastructure.EF.interfaces;
using Infrastructure.EF.repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetASP.Controllers.Shared;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("Jwt");
if (string.IsNullOrEmpty(jwtSettings["Key"]))
{
    Console.WriteLine("Jwt Key is null or empty");
}
else
{
    Console.WriteLine("Jwt Key loaded successfully");
}

// Add services to the container.
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["jwt_token"];
                return Task.CompletedTask;
            }
        };
    });

var corsPolicyName = "AllowSpecificOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


builder.Services.AddDbContext<QuizzDbContext>(cfg =>
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// You can also define a global rule to generate unique schema names based on the full type name,
// which is often useful for avoiding conflicts.
builder.Services.AddSwaggerGen(c => { c.CustomSchemaIds(type => type.FullName.Replace("+", ".")); });
// DbContext
builder.Services.AddScoped<QuizzDbContext>();

// Repository
// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Quizzes
builder.Services.AddScoped<IQuizzRepository, QuizzesRepository>();
// Scores
builder.Services.AddScoped<IScoreRepository, ScoreRepository>();
// Themes
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();
// Questions
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

// Handler
// User
builder.Services.AddScoped<UsersCreateHandler>();
builder.Services.AddScoped<UsersDeleteHandler>();
builder.Services.AddScoped<UsersUpdateHandler>();
builder.Services.AddScoped<UsersLoginHandler>();
builder.Services.AddScoped<UsersGetAllHandler>();
builder.Services.AddScoped<UsersGetByIdHandler>();
// Quizzes
builder.Services.AddScoped<QuizzesCreateHandler>();
builder.Services.AddScoped<QuizzesDeleteHandler>();
builder.Services.AddScoped<QuizzesUpdateHandler>();
builder.Services.AddScoped<QuizzesGetAllHandler>();
builder.Services.AddScoped<QuizzesGetByIdHandler>();

// Scores
builder.Services.AddScoped<ScoreCreateHandler>();
builder.Services.AddScoped<ScoreGetAllHandler>();
builder.Services.AddScoped<ScoreGetByIdHandler>();
builder.Services.AddScoped<ScoreGetByUserIdHandler>();
builder.Services.AddScoped<ScoreGetByQuizzIdHandler>();

// Themes
builder.Services.AddScoped<ThemeCreateHandler>();
builder.Services.AddScoped<ThemeGetAllHandler>();
builder.Services.AddScoped<ThemeDeleteHandler>();
builder.Services.AddScoped<ThemeUpdateHandler>();

// Question
builder.Services.AddScoped<QuestionCreateHandler>();
builder.Services.AddScoped<QuestionDeleteHandler>();
builder.Services.AddScoped<QuestionUpdateHandler>();

// Procceseur
// User
builder.Services.AddScoped<UsersCommandsProcessors>();
builder.Services.AddScoped<UsersQueryProcessors>();
// Quizzes
builder.Services.AddScoped<QuizzesCommandsProcessors>();
builder.Services.AddScoped<QuizzesQueryProcessors>();

// Scores
builder.Services.AddScoped<ScoreCommandProcessor>();
builder.Services.AddScoped<ScoreQueryProcessor>();

// Themes
builder.Services.AddScoped<ThemeCommandProcessor>();
builder.Services.AddScoped<ThemeQueryProcessor>();

// Question
builder.Services.AddScoped<QuestionCommandProcessor>();
// builder.Services.AddScoped<>();

// Token
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

// MiddleWare
// app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicyName);

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();