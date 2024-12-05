using AutoMapper;
using CleanArchitecture.Application.Common.Models.PlayerGroup;

namespace CleanArchitecture.Application.Common.Mappings;

public class MapPlayerGroup : Profile
{
    public MapPlayerGroup()
    {
        CreateMap<PlayerGroup, PlayerGroupResponse>().ReverseMap();
    }
      
}