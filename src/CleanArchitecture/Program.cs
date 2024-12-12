using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Web.Extensions;
using CleanArchitecture.Application;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Infrastructure.Data;
using AutoMapper;
using Microsoft.Extensions.FileProviders;

namespace CleanArchitecture.Frontend;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Konfigurasi CORS untuk API dan frontend
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
        });

        // Konfigurasi backend (API)
        var configuration = builder.Configuration.Get<AppSettings>()
            ?? throw ProgramException.AppsettingNotSetException();
        builder.Services.AddSingleton(configuration);
        builder.Services.AddValidationService();

        // Konfigurasi DbContext untuk frontend
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Konfigurasi AutoMapper
        builder.Services.AddAutoMapperConfiguration();

        // Tambahkan service yang dibutuhkan untuk backend
        builder.Services.AddCustomService(); // Tambahkan layanan backend lainnya di sini

        // Menambahkan Razor Pages untuk frontend
        builder.Services.AddRazorPages();

        // Bangun aplikasi dan konfigurasikan pipeline
        var app = await builder.ConfigureServices(configuration).ConfigurePipelineAsync(configuration);

        // Jika ada argumen "seed", lakukan seeding database
        if (args.Length > 0 && args[0] == "seed")
        {
            new SeedDatabaseCommand(app.Services);
            return;
        }

        // Konfigurasi middleware untuk API dan frontend
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles(); // Menyajikan file statis (dibutuhkan untuk frontend)

        app.UseRouting();

        // Gunakan CORS untuk komunikasi antara frontend dan backend (jika perlu)
        app.UseCors();

        // Menambahkan middleware untuk otorisasi (jika dibutuhkan untuk frontend atau backend)
        app.UseAuthorization();

        // Peta Razor Pages untuk frontend
        app.MapRazorPages();

        // Peta API Controllers (jika dibutuhkan untuk backend)
        app.MapControllers(); // Peta controller API di sini

        // Jalankan aplikasi
        await app.RunAsync();
    }
}
