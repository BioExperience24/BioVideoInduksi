using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Pages.License
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
            ViewData["Title"] = "License";
        }
    }
}