using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Infrastructure;
using CQRS.Boilerplate.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddApplicationDependencies();
services.AddApplication();
services.AddInfrastructure(builder.Configuration);
services.AddSwaggerGen();

var app = builder.Build();

var context = app.Services.GetService<IQueryDbContext>();
context.EnsureDbCreated();

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
