using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Pages.Login
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IConfiguration _configuration;

        public Index(ILogger<Index> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value ?? "";

        public void OnGet()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;
        }

        public void OnPost()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;
        }
    }
}