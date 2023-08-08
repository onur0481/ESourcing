using SourcingService.API.Extensions.Middlewares;
using SourcingService.API.Extensions.Registrations;
using SourcingService.API.Hubs;
using SourcingService.Application.Extensions.Registrations;
using SourcingService.Infrastructure.Extensions.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Extends services with consul services
builder.Services.ConfigureConsul(builder.Configuration);

// Extends services with application layer services
builder.Services.AddApplicationServices(builder.Configuration);

// Extends services with infrastructure layer services
builder.Services.AddInfratructureServices(builder.Configuration);

// Extends services with api layer services
builder.Services.AddAPIServices(builder.Configuration);

builder.Services.AddSignalR();

// Allows all CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials().WithOrigins("https://localhost:44357"));
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
app.MapHub<AuctionHub>("/auctionhub");
// Use custom logger middleware to manage logs and exception responses
app.UseMiddleware<LoggerMiddleware>();

// Use routing first
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Start();
app.RegisterWithConsul(app.Lifetime, builder.Configuration);
app.WaitForShutdown();
