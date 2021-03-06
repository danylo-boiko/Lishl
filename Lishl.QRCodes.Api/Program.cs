using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Lishl.Authentication.Core;
using Lishl.Core.Repositories;
using Lishl.Core.Requests.QRCode;
using Lishl.Core.Validators.QRCode;
using Lishl.Infrastructure.MongoDb;
using Lishl.Infrastructure.MongoDb.Repositories;
using Lishl.QRCodes.Api.QRCodeService;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDb(builder.Configuration.GetConnectionString("MongoDbDatabase"), 
    builder.Configuration.GetConnectionString("MongoDbConnection"));
builder.Services.AddScoped<IQRCodesRepository, QRCodesRepository>();
builder.Services.AddScoped<IQRCodeService, QRCodeService>();

builder.Services.AddFluentValidation();
builder.Services.AddTransient<IValidator<CreateQRCodeRequest>, CreateQRCodeRequestValidator>();
builder.Services.AddTransient<IValidator<UpdateQRCodeRequest>, UpdateQRCodeRequestValidator>();

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