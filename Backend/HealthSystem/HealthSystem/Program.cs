using HealthSystem.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Bugsnag.AspNet.Core;
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure BugSnag
builder.Services.AddBugsnag(configuration =>
{
    configuration.ApiKey = "cc8bdb23dae08cfcc5e4eb3429eced49"; 
});

// Retrieve the DB_PASSWORD from environment variables
var dbPassword = builder.Configuration["DB_PASSWORD"];

// Update the connection string with the password from the environment variable
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection").Replace("{DB_PASSWORD}", dbPassword);

// Configure DbContext with MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // The URL of your Angular app
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}
// Enable CORS (Cross-Origin Requests)
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add BugSnag Middleware to handle unhandled exceptions
// Â‰« ‰” Œœ„ ILogger · ”ÃÌ· «·√Œÿ«¡ ›Ì BugSnag
// «” Œœ„ `ILogger` ·«· ﬁ«ÿ «·√Œÿ«¡
app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception ex)
    {
        // ”Ã· «·Œÿ√ ›Ì BugSnag »«” Œœ«„ `ILogger`
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred");

        // √⁄œ ≈·ﬁ«¡ «·«” À‰«¡ »⁄œ  ”ÃÌ·Â
        throw;
    }
});
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
