using Ocelot.Middleware;
using Web.APIGateway.Extensions.Middlewares;
using Web.APIGateway.Extensions.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json").AddEnvironmentVariables()
    .AddJsonFile($"ocelot.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false);

// Extends services with api gateway layer services
builder.Services.AddAPIGatewayServices(builder.Configuration);

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

await app.UseOcelot();

app.Run();
