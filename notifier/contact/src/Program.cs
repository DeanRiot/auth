using contacts.Models;
using contacts.Models.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var sql_provider_name = Environment.GetEnvironmentVariable("PROVIDER_NAME");
if (sql_provider_name is null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("PROVIDER_NAME enviroment var is misconfigured");
    Console.ForegroundColor = ConsoleColor.White;
    return;
}
string sql_cs = Environment.GetEnvironmentVariable(sql_provider_name);
if (sql_cs is null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("DB Connection string enviroment var is misconfigured");
    Console.ForegroundColor = ConsoleColor.White;
    return;
}
if (Environment.GetEnvironmentVariable("AUTH_ADDRESS") is null)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("AUTH_ADDRESS enviroment var is misconfigured");
    Console.ForegroundColor = ConsoleColor.White;
    return;
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NotifyContext>(options =>
                 options.UseNpgsql(sql_cs));

builder.Services.AddScoped<IAuthInfo, AuthConnectionInfo>();
builder.Services.AddScoped<NotifyContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
