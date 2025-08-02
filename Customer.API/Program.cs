using Customer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------
// Configure Services
// ----------------------------------------

// Retrieve connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with SQL Server provider
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

// Register MVC controllers
builder.Services.AddControllers();

// Swagger / OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------------------------
// Configure Middleware
// ----------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();