using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ContainerDependencies();

// Add services to the container.
builder.Services.AddControllersWithViews().AddNToastNotifyNoty(new NToastNotify.NotyOptions()
{
    ProgressBar = true,
    Timeout = 4000,
    Theme = "mint"
});
var app = builder.Build();
app.UseNToastNotify();

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
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
