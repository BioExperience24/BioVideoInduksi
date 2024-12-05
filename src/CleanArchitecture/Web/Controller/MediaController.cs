using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Media;
using CleanArchitecture.Web.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace CleanArchitecture.Web.Controller;

public class MediaController(IMediaService mediaService, IFileUploadService fileUploadService) : BaseController
{
    private readonly IMediaService _mediaService = mediaService;
    private readonly IFileUploadService _fileUploadService = fileUploadService;


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _mediaService.Get(id));

    [HttpGet]
    public async Task<IActionResult> GetAll(int pageIndex = 0, int pageSize = 50)
    {
        return Ok(await _mediaService.GetCollection(pageIndex, pageSize));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] MediaRequest request, [FromServices] IValidator<MediaRequest> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _mediaService.Add(request, token);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] MediaRequestUpdate request, [FromServices] IValidator<MediaRequestUpdate> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _mediaService.Update(request, token);
        
        return Ok();
    }


    // [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await _mediaService.Delete(id, token);
        return NoContent();
    }
}
