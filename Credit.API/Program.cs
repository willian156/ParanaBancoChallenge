using Credit.API.Middlewares;
using Credit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ======================
// Configure DbContext
// ======================
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

// ======================
// Register application services
// ======================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ======================
// Enable CORS
// ======================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// ======================
// Configure HTTP request pipeline
// ======================
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