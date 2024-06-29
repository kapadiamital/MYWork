using Microsoft.EntityFrameworkCore;
using Menu.Data;


// Add services to the container.
WebApplication.CreateBuilder(args).Services.AddControllersWithViews();

WebApplication.CreateBuilder(args).Services.AddDbContext<MenuContext>(options =>
    options.UseSqlServer(WebApplication.CreateBuilder(args).Configuration.GetConnectionString("DefaultConnectionString")));


var app = WebApplication.CreateBuilder(args).Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();