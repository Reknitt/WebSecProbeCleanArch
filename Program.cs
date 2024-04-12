using MediatR;
using Presentation.Domain.Interfaces;
using WebSecProbeCleanArch.Application.Commands.UserCommands.Create;
using WebSecProbeCleanArch.Controllers.VulnerabilityControllers;
using WebSecProbeCleanArch.Infrastructure.DbContexts;
using WebSecProbeCleanArch.Infrastructure.Repositories.UserRepository;
using WebSecProbeCleanArch.Infrastructure.Repositories.VulnerabilityRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<SqliteDbContext>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IVulnerabilityRepository, EfVulnerabilityRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => {
            builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowSpecificOrigin");
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
