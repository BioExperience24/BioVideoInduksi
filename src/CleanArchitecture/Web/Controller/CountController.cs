using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controller;

public class CountController(ICountService countService) : BaseController
{
    private readonly ICountService _countService = countService;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Show()
    {
        return Ok(await _countService.Show());
    }
}
