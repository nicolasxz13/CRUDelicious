using Microsoft.EntityFrameworkCore;
using CRUDelicious.Data;

var builder = WebApplication.CreateBuilder(args);

// Add our service
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DeliciousContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(    
    name: "default",    
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
