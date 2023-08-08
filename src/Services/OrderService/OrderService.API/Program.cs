using Autofac;
using Autofac.Extensions.DependencyInjection;
using OrderService.API.Extensions.Middlewares;
using OrderService.API.Extensions.Registrations;
using OrderService.Application.Extensions.Modules;
using OrderService.Application.Extensions.Registrations;
using OrderService.Infrastructure.Extensions.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For dependency injection with Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new DependencyInjectionModule()));

// Extends services with consul services
builder.Services.ConfigureConsul(builder.Configuration);

// Extends services with infrastructure layer services
builder.Services.AddInfrastructureServices(builder.Configuration);

//Extends services with application layer services
builder.Services.AddApplicationServices(builder.Configuration);

//Extends services with application layer services
builder.Services.AddAPIServices(builder.Configuration);

// Allows all CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Allow all CORS
app.UseCors("AllowAll");

// Use custom logger middleware to manage logs and exception responses
app.UseMiddleware<LoggerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Start();
app.RegisterWithConsul(app.Lifetime, builder.Configuration);
app.WaitForShutdown();
