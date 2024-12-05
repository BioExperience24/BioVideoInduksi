using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.PlayerGroup;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Frontend.Pages.PlayerGroup
{
    public class Index : PageModel
    {
        private readonly IPlayerGroupService _playerGroupService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public IEnumerable<PlayerGroupResponse> Items { get; set; }

        public Index(IPlayerGroupService playerGroupService, IMapper mapper, IConfiguration configuration)
        {
            _playerGroupService = playerGroupService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value;

        public async Task OnGetAsync()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;
            ViewData["Title"] = "Player Group";

            var playerGroupCollection = await _playerGroupService.GetCollection(1, 50);

            Items = _mapper.Map<IEnumerable<PlayerGroupResponse>>(playerGroupCollection.Collection);
        }
    }
}
