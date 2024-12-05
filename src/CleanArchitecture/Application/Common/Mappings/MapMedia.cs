using AutoMapper;
using CleanArchitecture.Application.Common.Models.Media;

namespace CleanArchitecture.Application.Common.Mappings;

public class MapMedia : Profile
{
    public MapMedia()
    {
        CreateMap<Media, MediaResponse>().ReverseMap();
    }
      
}
