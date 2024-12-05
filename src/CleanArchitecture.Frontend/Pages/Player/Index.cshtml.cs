using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Player;
using CleanArchitecture.Application.Common.Models.PlayerGroup;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Frontend.Pages.Player
{
    public class Index : PageModel
    {
        private readonly IPlayerService _playerService;
        private readonly IPlayerGroupService _playerGroupService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public IEnumerable<PlayerResponse> Items { get; set; }
        public IEnumerable<PlayerGroupResponse> ItemPlayerGroups { get; set; }

        public Index(IPlayerService playerService, IPlayerGroupService playerGroupService, IMapper mapper, IConfiguration configuration)
        {
            _playerService = playerService;
            _playerGroupService = playerGroupService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value;

        public async Task OnGetAsync()
        {
            ViewData["BaseUrlApi"] = baseUrlApi;
            ViewData["Title"] = "Player";

            var playerCollection = await _playerService.GetCollection(1, 50);
            var playerGroupCollection = await _playerGroupService.GetCollection(1, 50);

            Items = _mapper.Map<IEnumerable<PlayerResponse>>(playerCollection.Collection);
            ItemPlayerGroups = _mapper.Map<IEnumerable<PlayerGroupResponse>>(playerGroupCollection.Collection);
        }
    }
}
