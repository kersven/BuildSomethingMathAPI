using MathApp.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<MathAPIService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=sqlexpress;Database=MathAppDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    // Retry logic to wait for SQL Server to be ready
    var retries = 3;
    while (retries > 0)
    {
        try
        {
            context.Database.Migrate();
            break;
        }
        catch (SqlException)
        {
            retries--;
            if (retries == 0) throw;
            Thread.Sleep(2000);
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
