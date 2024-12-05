using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Media;
using CleanArchitecture.Web.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace CleanArchitecture.Web.Controller;

public class PlayerGroupController(IPlayerGroupService playerGroupService) : BaseController
{
    private readonly IPlayerGroupService _playerGroupService = playerGroupService;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _playerGroupService.Get(id));

    [HttpGet]
    public async Task<IActionResult> GetAll(int pageIndex = 0, int pageSize = 50)
    {
        return Ok(await _playerGroupService.GetCollection(pageIndex, pageSize));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] PlayerGroupAddRequest request, [FromServices] IValidator<PlayerGroupAddRequest> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _playerGroupService.Add(request, token);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromForm] PlayerGroupUpdateRequest request, [FromServices] IValidator<PlayerGroupUpdateRequest> validator, CancellationToken token)
    {
        var validationResult = await validator.ValidateAsync(request, token);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        await _playerGroupService.Update(request, token);
        
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await _playerGroupService.Delete(id, token);
        return NoContent();
    }
}
