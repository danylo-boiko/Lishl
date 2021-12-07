using System.Reflection;
using Lishl.Authentication;
using Lishl.Authentication.Configurations;
using Lishl.Authentication.Interfaces;
using Lishl.Authentication.Services;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using Lishl.Infrastructure.PostgreSql;
using Lishl.Infrastructure.PostgreSql.Repositories;
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

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(GetUserByEmailQueryHandler).GetTypeInfo().Assembly);

builder.Services.AddJwtAuthentication(builder.Configuration);

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