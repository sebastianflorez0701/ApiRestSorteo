using Datos;
using Microsoft.EntityFrameworkCore;
using Negocio.Interfaces;
using Negocio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<SorteosDbContext>(x => x.UseSqlServer(conn));

builder.Services.AddScoped<ICliente, ServiceCliente>();
builder.Services.AddScoped<IUsuario, ServiceUsuario>();
builder.Services.AddScoped<ISorteo, ServiceSorteo>();
builder.Services.AddScoped<INumerosAsignados, ServiceNumerosAsignados>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
