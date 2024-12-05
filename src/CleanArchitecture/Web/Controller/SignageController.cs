using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Signage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace CleanArchitecture.Web.Controller;

public class SignageController(ISignageService signageService) : BaseController
{
    private readonly ISignageService _signageService = signageService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _signageService.Get(id));

    [HttpGet]
    public async Task<IActionResult> GetAll(int pageIndex = 0, int pageSize = 50)
    {
        return Ok(await _signageService.GetCollection(pageIndex, pageSize));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] SignageRequestAdd request, [FromServices] IValidator<SignageRequestAdd> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _signageService.Add(request, token);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] SignageRequestUpdate request, [FromServices] IValidator<SignageRequestUpdate> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _signageService.Update(request, token);
        
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await _signageService.Delete(id, token);
        return NoContent();
    }
}
