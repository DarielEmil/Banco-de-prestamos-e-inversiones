using DinkToPdf;
using DinkToPdf.Contracts;
using CoopDEJC.Extension;
using CoopDEJC.Models.CoopDBModels;
using CoopDEJC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var context = new CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "LibreriaPDF/libwkhtmltox.dll"));
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


//Conexion a la Base de datos
builder.Services.AddDbContext<CoopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CoopConnection"))
);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var Context = scope.ServiceProvider.GetRequiredService<CoopContext>();
    Context.Database.Migrate();
}

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
    name: "Index",
    pattern: "Index",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "MyProfile",
    pattern: "MyProfile",
    defaults: new { controller = "Home", action = "MyProfile" });

app.MapControllerRoute(
    name: "Investment",
    pattern: "Investment/{action}",
    defaults: new { controller = "Investment", action = "Investment" });

app.MapControllerRoute(
    name: "Loans",
    pattern: "Loans",
    defaults: new { controller = "Loans", action = "Loans" });

app.MapControllerRoute(
    name: "Login",
    pattern: "Login",
    defaults: new { controller = "Login", action = "Login" });

app.MapControllerRoute(
    name: "Register",
    pattern: "Register",
    defaults: new { controller = "Login", action = "Register" });

app.MapControllerRoute(
    name: "SignOut",
    pattern: "SignOut",
    defaults: new { controller = "Login", action = "SignOut" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");
app.Run();
