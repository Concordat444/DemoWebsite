using Microsoft.EntityFrameworkCore;
using DemoWebsite.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:DemoStoreConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute("catpage", "{category}/Page{ProductPage:int}", new { Controller = "Home", Action = "Index" });
app.MapControllerRoute("page", "Page{ProductPage:int}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapDefaultControllerRoute();

SeedStoreData.EnsurePopulated(app);

app.Run();
