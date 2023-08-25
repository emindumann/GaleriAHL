using GaleriAHL.Business.Abstract;
using GaleriAHL.Business.Concrete;
using GaleriAHL.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));//Bu yapýyý WebUI'da kullanabilmek için Sistemi Services olarak AddTransient methodu ile ekledik. Bu iþlem .NetCore'un container yapýsýnda kendi yazdýðýmýz IServis ara katmaný kullanabilmemizi saðlayan bir yapýdýr.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie( x =>
{
    x.LoginPath = "/Admin/Login";
    x.AccessDeniedPath = "/AccessDenied";
    x.LogoutPath = "/Admin/Logout";
    x.Cookie.Name= "Admin";
    x.Cookie.MaxAge = TimeSpan.FromDays(7);
    x.Cookie.IsEssential = true;
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin"));
    x.AddPolicy("ManagerPolicy", policy => policy.RequireClaim("Role", "Manager"));
});

var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute( //endpoint
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
