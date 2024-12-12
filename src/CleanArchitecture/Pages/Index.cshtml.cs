using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArchitecture.Pages;

public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;

    public IndexModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value ?? string.Empty;

    public void OnGet()
    {
        ViewData["BaseUrlApi"] = baseUrlApi;
    }
}
