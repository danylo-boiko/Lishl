using System;
using System.Reflection;
using GraphQL.Server;
using GraphQL.Types;
using Lishl.Core;
using Lishl.Core.Services;
using Lishl.GraphQL.GraphQL.Mutations;
using Lishl.GraphQL.GraphQL.Queries;
using Lishl.GraphQL.GraphQL.Schemas;
using Lishl.GraphQL.GraphQL.Types;
using Lishl.GraphQL.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(HttpClientNames.UsersClient, client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("UsersService"));
});

builder.Services.AddHttpClient(HttpClientNames.LinksClient, client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("LinksService"));
});

builder.Services.AddHttpClient(HttpClientNames.QRCodesClient, client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("QRCodesService"));
});

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ILinksService, LinksService>();
builder.Services.AddScoped<IQRCodesService, QRCodesService>();

builder.Services.AddScoped<LishlQuery>();
builder.Services.AddScoped<LishlMutation>();

builder.Services.AddScoped<UserType>();
builder.Services.AddScoped<LinkType>();
builder.Services.AddScoped<QRCodeType>();
builder.Services.AddScoped<LinkFollowType>();
builder.Services.AddScoped<UserRoleType>();
            
builder.Services.AddScoped<CreateUserType>();
builder.Services.AddScoped<CreateLinkType>();
builder.Services.AddScoped<CreateQRCodeType>();

builder.Services.AddScoped<UpdateUserType>();
builder.Services.AddScoped<UpdateLinkType>();
builder.Services.AddScoped<UpdateQRCodeType>();

builder.Services.AddScoped<LinkFollowInputType>();

builder.Services.AddScoped<ISchema, LishlSchema>();

builder.Services.AddGraphQL(opt =>
{
    opt.EnableMetrics = true;
}).AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true).AddSystemTextJson();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddCors();


var app = builder.Build();

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyOrigin().AllowAnyHeader());
app.UseGraphQL<ISchema>();
app.UseGraphQLPlayground();
app.UseRouting();

app.Run();