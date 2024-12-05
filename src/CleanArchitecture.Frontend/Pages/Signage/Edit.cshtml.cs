using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Web.Requests;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Signage;
using CleanArchitecture.Application.Common.Models.Template;
using CleanArchitecture.Application.Common.Models.Media;

namespace CleanArchitecture.Frontend.Pages.Signage;

public class Edit : PageModel
{
    private readonly ITemplateService _templateService;
    private readonly IMediaService _mediaService;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public IEnumerable<TemplateResponse> ItemTemplates { get; set; }
    public IEnumerable<MediaResponse> ItemMedias { get; set; }

    public Edit(
        ITemplateService templateService,
        IMediaService mediaService,
        IMapper mapper,
        IConfiguration configuration
    )
    {
        _templateService = templateService;
        _mediaService = mediaService;
        _mapper = mapper;
        _configuration = configuration;
    }

    public string baseUrlApi => _configuration.GetSection("AppSettings:BaseUrlApi").Value;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        ViewData["BaseUrlApi"] = baseUrlApi;
        ViewData["Title"] = "Edit Signage";
        ViewData["Id"] = id;

        var templateCollection = await _templateService.GetCollection(1, 50);
        var mediaCollection = await _mediaService.GetCollection(1, 50);

        ItemTemplates = _mapper.Map<IEnumerable<TemplateResponse>>(templateCollection.Collection);
        ItemMedias = _mapper.Map<IEnumerable<MediaResponse>>(mediaCollection.Collection);

        return Page();
    }
}
