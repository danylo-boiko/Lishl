using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Lishl.Authentication.AuthenticationService;
using Lishl.Authentication.Core;
using Lishl.Authentication.Core.Configurations;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using Lishl.Core.Requests.Auth;
using Lishl.Core.Validators.Auth;
using Lishl.Infrastructure.PostgreSql;
using Lishl.Infrastructure.PostgreSql.Repositories;
using Lishl.Users.Api;
using Lishl.Users.Api.Cqrs.Commands.Handlers;
using Lishl.Users.Api.Cqrs.Queries.Handlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPostgreSql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<ITokenConfiguration, TokenConfiguration>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddFluentValidation();
builder.Services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
builder.Services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
builder.Services.AddMediatR(typeof(GetUserByEmailQueryHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();