using Demo_ASP_MVC_06_Session.BLL.Interfaces;
using Demo_ASP_MVC_06_Session.BLL.Services;
using Demo_ASP_MVC_06_Session.DAL.Interfaces;
using Demo_ASP_MVC_06_Session.DAL.Repositories;
using Demo_ASP_MVC_06_Session.WebApp.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Injection
// - Connection SQL
builder.Services.AddScoped<IDbConnection>(service =>
{
    return new SqlConnection(builder.Configuration.GetConnectionString("default"));
});
// - DAL
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
// - BLL
builder.Services.AddScoped<IMemberService, MemberService>();


// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<SessionService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
