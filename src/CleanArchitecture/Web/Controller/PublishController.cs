using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Media;
using CleanArchitecture.Web.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace CleanArchitecture.Web.Controller;

public class PublishController(IPublishService publishService) : BaseController
{
    private readonly IPublishService _publishService = publishService;

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Get(int id) => Ok(await _publishService.Get(id));

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll(int pageIndex = 0, int pageSize = 50)
    {
        return Ok(await _publishService.GetCollection(pageIndex, pageSize));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromForm] PublishRequestAdd request, [FromServices] IValidator<PublishRequestAdd> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _publishService.Add(request, token);
        return Ok();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromForm] PublishRequestUpdate request, [FromServices] IValidator<PublishRequestUpdate> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _publishService.Update(request, token);
        
        return Ok();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await _publishService.Delete(id, token);
        return NoContent();
    }
}
