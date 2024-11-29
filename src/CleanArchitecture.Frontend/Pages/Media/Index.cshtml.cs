using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Media;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Frontend.Pages.Media
{
    public class Media : PageModel
    {
        private readonly IMediaService _mediaService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        // Properti untuk simpan data
        public IEnumerable<MediaDTO> Items { get; set; }

        // Inject service dan mapper
        public Media(IMediaService mediaService, IMapper mapper, IConfiguration configuration)
        {
            _mediaService = mediaService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value;

        public async Task OnGetAsync()
        {
            // Console.WriteLine("+========================+");
            // Console.WriteLine("debug: {0}", baseUrlApi);
            // Console.WriteLine("+========================+");

            // parsing data to view
            ViewData["BaseUrlApi"] = baseUrlApi;

            // Get data from database
            var mediaCollection = await _mediaService.GetCollection(1, 50);

            // Mapping data dari domain ke DTO
            Items = _mapper.Map<IEnumerable<MediaDTO>>(mediaCollection.Collection);
        }
    }
}
