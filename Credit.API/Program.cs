using Credit.API.Configurations;
using Credit.API.Middlewares;
using Credit.Application.Interfaces;
using Credit.Application.Repositories;
using Credit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Register the dependency injection
builder.Services.AddScoped<ICreditProposalRepository, CreditProposalRepository>();

// Register Configuration
builder.Services.AddApplicationServices(builder.Configuration);

// ----------------------------------------
// Configure DbContext
// ----------------------------------------
builder.Services.AddDbContext<DataContext>(options =>
{
    // Retrieve connection string from appsettings.json
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Configure SQL Server provider and specify the assembly where migrations are stored
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.MigrationsAssembly("Credit.Infrastructure");
    });
});


// ----------------------------------------
// Register application services
// ----------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ----------------------------------------
// Enable CORS
// ----------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Apply the migrations automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    db.Database.Migrate();
}

// ----------------------------------------
// Configure Middleware
// ----------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Enable global CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();