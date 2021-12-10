using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Lishl.Authentication.Core;
using Lishl.Core.Repositories;
using Lishl.Core.Requests.Link;
using Lishl.Core.Validators.Link;
using Lishl.Infrastructure.MongoDb;
using Lishl.Infrastructure.MongoDb.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDb("linksservice", builder.Configuration.GetConnectionString("MongoDbConnection"));
builder.Services.AddScoped<ILinksRepository, LinksRepository>();

builder.Services.AddFluentValidation();
builder.Services.AddTransient<IValidator<CreateLinkRequest>, CreateLinkRequestValidator>();
builder.Services.AddTransient<IValidator<UpdateLinkRequest>, UpdateLinkRequestValidator>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddJwtAuthentication(builder.Configuration);

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();