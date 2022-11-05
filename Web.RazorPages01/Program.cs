using Microsoft.EntityFrameworkCore;
using Web.RazorPages01.Data;
using Web.RazorPages01.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddDbContext<AppDataContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("AppConnection")
                                 ?? throw new InvalidOperationException("Connection string not found. Have you added the connection string to your appsettings.json?")));

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Run the Movie seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    SeedMovies.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();