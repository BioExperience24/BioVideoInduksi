using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Signage;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Frontend.Pages.Signage
{
    public class Index : PageModel
    {
        private readonly ISignageService _signageService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public IEnumerable<SignageResponse> Items { get; set; }

        public Index(ISignageService signageService, IMapper mapper, IConfiguration configuration)
        {
            _signageService = signageService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value;

        public async Task OnGetAsync()
        {
            // parsing data to view
            ViewData["BaseUrlApi"] = baseUrlApi;
            ViewData["Title"] = "Signage";

            // Get data from database
            var signageCollection = await _signageService.GetCollection(1, 50);

            Items = _mapper.Map<IEnumerable<SignageResponse>>(signageCollection.Collection);
        }
    }
}