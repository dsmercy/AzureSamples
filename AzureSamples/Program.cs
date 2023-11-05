using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AzureSamplesCosmosDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSamplesCosmosDBContext") ?? throw new InvalidOperationException("Connection string 'AzureSamplesCosmosDBContext' not found.")));
builder.Services.AddDbContext<AzureSamplesMySQLDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSamplesMySQLDBContext") ?? throw new InvalidOperationException("Connection string 'AzureSamplesMySQLDBContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
