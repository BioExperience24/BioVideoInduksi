using AutoMapper;
using CleanArchitecture.Application.Common.Models.Publish;

namespace CleanArchitecture.Application.Common.Mappings;

public class MapPublish : Profile
{
    public MapPublish()
    {
        CreateMap<Publish, PublishResponse>()
            // Menambahkan pemetaan khusus untuk properti PublishType
            .ForMember(dest => dest.PublishType, opt => opt.MapFrom(src => src.PublishType));
    }

}