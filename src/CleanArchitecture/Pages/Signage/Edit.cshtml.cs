using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Frontend.Pages.Signage;

public class Edit : PageModel
{
    private readonly IConfiguration _configuration;

    public Edit(
        IConfiguration configuration
    )
    {
        _configuration = configuration;
    }

    public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value ?? "";

    public IActionResult OnGetAsync(int id = 0)
    {
        ViewData["BaseUrlApi"] = baseUrlApi;
        ViewData["Title"] = "Edit Signage";
        ViewData["Id"] = id;

        return Page();
    }
}
