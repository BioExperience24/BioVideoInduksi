using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Web.Services;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Web.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapper;

namespace CleanArchitecture.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IMediaService, MediaService>();
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IFileUploadService, FileUploadService>();

        services.AddSingleton<ICurrentTime, CurrentTime>();
        services.AddSingleton<ICurrentUser, CurrentUser>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddSingleton<ICookieService, CookieService>();

        return services;
    }

    public static void AddValidationService(this IServiceCollection services)
    {
        services.AddControllers()
        .AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblyContaining<MediaRequestValidation>(); // Validator untuk MediaRequest
            fv.RegisterValidatorsFromAssemblyContaining<MediaRequestUpdateValidation>(); // Validator untuk MediaRequestUpdate
            fv.RegisterValidatorsFromAssemblyContaining<TemplateRequestUpdateValidation>(); 
        });
    }


    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IMediaService, MediaService>();
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IFileUploadService, FileUploadService>();
    }

    // automapper untuk frontend
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapMedia));
        services.AddAutoMapper(typeof(MapTemplate));
    }
}
