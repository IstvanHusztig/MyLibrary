using Microsoft.EntityFrameworkCore;
using MyLibrary.Injectors;
using MyLibrary.Inrastructure;

var builder = WebApplication.CreateBuilder(args);

Injectors.DefineInjectors(builder.Services);

builder.Services.AddDbContext<MyLibraryDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultValue")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.Run();
