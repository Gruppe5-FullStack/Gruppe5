﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Gruppe5.Data;
using Gruppe5.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Gruppe5Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Gruppe5Context") ?? throw new InvalidOperationException("Connection string 'Gruppe5Context' not found.")));

/*// Add services to the container.
builder.Services.AddControllersWithViews();*/

builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<WeatherService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
