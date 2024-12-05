using AutoMapper;
using CleanArchitecture.Application.Common.Models.Player;

namespace CleanArchitecture.Application.Common.Mappings;

public class MapPlayer : Profile
{
    public MapPlayer()
    {
        CreateMap<Player, PlayerResponse>().ReverseMap();
    }
      
}