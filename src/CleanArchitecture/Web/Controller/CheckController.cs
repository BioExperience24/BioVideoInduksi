using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controller;

public class CheckController(ICheckService checkService) : BaseController
{
    private readonly ICheckService _checkService = checkService;

    [HttpGet("Update/{serial}")]
    public async Task<IActionResult> Show([FromRoute] string serial, CancellationToken token)
    {
        return Ok(await _checkService.Show(serial, token));
    }
}
