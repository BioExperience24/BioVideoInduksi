using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Media;
using CleanArchitecture.Web.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace CleanArchitecture.Web.Controller;

public class TemplateController(ITemplateService templateService) : BaseController
{
    private readonly ITemplateService _templateService = templateService;

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Get(int id) => Ok(await _templateService.Get(id));

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll(int pageIndex = 0, int pageSize = 50)
    {
        return Ok(await _templateService.GetCollection(pageIndex, pageSize));
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromForm] TemplateRequestUpdate request, [FromServices] IValidator<TemplateRequestUpdate> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _templateService.Update(request, token);
        
        return Ok();
    }
}
