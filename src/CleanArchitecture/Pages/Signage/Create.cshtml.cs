using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Frontend.Pages.Signage
{
    public class Create : PageModel
    {
        private readonly IConfiguration _configuration;

        public Create(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value ?? "";
        public void OnGet()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;
            ViewData["Title"] = "Create Signage";
        }
    }
}