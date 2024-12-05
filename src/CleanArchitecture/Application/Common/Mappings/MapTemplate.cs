using AutoMapper;
using CleanArchitecture.Application.Common.Models.Template;

namespace CleanArchitecture.Application.Common.Mappings;

public class MapTemplate : Profile
{
    public MapTemplate()
    {
        CreateMap<Template, TemplateResponse>().ReverseMap();
    }
      
}