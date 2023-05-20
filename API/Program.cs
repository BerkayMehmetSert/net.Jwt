using System.Text;
using API.Application;
using API.Application.Constants.Extensions;
using API.Application.Constants.Services;
using API.Infrastructure.Exceptions;
using API.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddCustomSwaggerServices();
builder.Services.AddJwtServices(builder.Services.BuildServiceProvider());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCustomExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();