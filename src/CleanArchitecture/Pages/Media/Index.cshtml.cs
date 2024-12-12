using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Pages.Media
{
    public class Index : PageModel
    {
        private readonly IConfiguration _configuration;

        // Inject service dan mapper
        public Index(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value ?? "";

        public void OnGet()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;
            ViewData["Title"] = "Media";
        }
    }
}
