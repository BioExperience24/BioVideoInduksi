using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Frontend.Pages.Template
{
    public class Index : PageModel
    {
        private readonly IConfiguration _configuration;

        public Index(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value ?? String.Empty;

        public void OnGet()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;
            ViewData["Title"] = "Template";
        }
    }
}