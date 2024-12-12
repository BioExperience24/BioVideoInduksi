using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Pages.DisplayTablet
{
    public class Index : PageModel
    {
        private readonly IConfiguration _configuration;

        public Index(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value ?? "";

        public void OnGet()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;
            ViewData["Title"] = "Display Tablet";
        }
    }
}
