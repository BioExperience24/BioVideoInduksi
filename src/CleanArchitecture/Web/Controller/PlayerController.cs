using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Media;
using CleanArchitecture.Web.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace CleanArchitecture.Web.Controller;

public class PlayerController(IPlayerService playerService) : BaseController
{
    private readonly IPlayerService _playerService = playerService;

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Get(int id) => Ok(await _playerService.Get(id));

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll(int pageIndex = 0, int pageSize = 50)
    {
        return Ok(await _playerService.GetCollection(pageIndex, pageSize));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromForm] PlayerAddRequest request, [FromServices] IValidator<PlayerAddRequest> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _playerService.Add(request, token);
        return Ok();
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromForm] PlayerUpdateRequest request, [FromServices] IValidator<PlayerUpdateRequest> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _playerService.Update(request, token);
        
        return Ok();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await _playerService.Delete(id, token);
        return NoContent();
    }
}
