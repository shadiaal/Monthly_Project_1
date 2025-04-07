using HealthSystem.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MySql.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
