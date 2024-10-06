using Data.Contexts;
using Data.UnitOfWorks;
using Logic.Interfaces;
using Logic.Interfaces.OutputInterfaces;
using Logic.Mappers;
using Logic.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var postgreSqlConnectionString = builder.Configuration.GetConnectionString("PostgreSqlDbConnection");

builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
    optionsBuilder.UseNpgsql(postgreSqlConnectionString)
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

string[] allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

app.UseCors(
    options => options.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
