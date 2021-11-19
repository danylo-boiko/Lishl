using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Lishl.Core.Models;
using Lishl.Core.Repositories;
using Lishl.Core.Requests;
using Lishl.Core.Validators;
using Lishl.Infrastructure.PostgreSql;
using Lishl.Infrastructure.PostgreSql.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPostgreSql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddFluentValidation();
builder.Services.AddTransient<IValidator<CreateUserRequest>, CreateUserRequestValidator>();
builder.Services.AddTransient<IValidator<UpdateUserRequest>, UpdateUserRequestValidator>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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

app.Run();