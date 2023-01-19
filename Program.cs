using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaulBejinariu_Project.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PaulBejinariu_ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaulBejinariu_ProjectContext") ?? throw new InvalidOperationException("Connection string 'PaulBejinariu_ProjectContext' not found.")));

var app = builder.Build();

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "books",
        pattern: "Books/AddRemoveBookRead/{id}/{handler}",
        defaults: new { controller = "Books", action = "AddRemoveBookRead" });
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
