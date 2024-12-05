using AutoMapper;
using CleanArchitecture.Application.Common.Models.Signage;

namespace CleanArchitecture.Application.Common.Mappings;

public class MapSignage : Profile
{
    public MapSignage()
    {
        CreateMap<Signage, SignageResponse>().ReverseMap();
    }
      
}