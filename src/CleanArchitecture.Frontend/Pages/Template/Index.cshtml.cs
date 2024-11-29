using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Template;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Frontend.Pages.Template
{
    public class Template : PageModel
    {
        private readonly ITemplateService _templateService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        // Properti untuk simpan data
        public IEnumerable<TemplateDTO> Items { get; set; }

        // Inject service dan mapper
        public Template(ITemplateService templateService, IMapper mapper, IConfiguration configuration)
        {
            _templateService = templateService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value;

        public async Task OnGetAsync()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;

            var templateCollection = await _templateService.GetCollection(1, 50);

            Items = _mapper.Map<IEnumerable<TemplateDTO>>(templateCollection.Collection);
        }
    }
}