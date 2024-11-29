using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using static CleanArchitecture.Application.ConfigureServices;
using AutoMapper;


namespace CleanArchitecture.Frontend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        // Tambahkan konfigurasi DbContext di sini
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddCustomService();
        builder.Services.AddAutoMapperConfiguration();

        var app = builder.Build();
        
        // Retrieve values from the configuration file
        var baseUrlApi = builder.Configuration.GetSection("AppSettings:BaseUrlApi").Value;

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
    }
}

