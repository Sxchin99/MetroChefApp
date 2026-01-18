using MetroChefApp.API.Data;
using Microsoft.EntityFrameworkCore;
using MetroChefApp.API.Repositories;
using MetroChefApp.API.Repositories.Interfaces;
using AutoMapper;
using MetroChefApp.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// -------------------- Services --------------------

// Add Razor Pages and API Controllers
builder.Services.AddRazorPages();
builder.Services.AddControllers(); // Register API controllers

// Add DbContext (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories (Dependency Injection)
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Enable CORS (allow Swagger to call API across ports/schemes)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------- App --------------------
var app = builder.Build();

// Middleware for non-development
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetroChef API V1");
});

// Enable HTTPS redirection and static files
app.UseHttpsRedirection();
app.UseStaticFiles();

// Enable CORS
app.UseCors("AllowAll");

app.UseRouting();
app.UseAuthorization();

// Map API Controllers and Razor Pages
app.MapControllers(); // <-- Needed for Swagger to see endpoints
app.MapRazorPages();

// Run the app
app.Run();
