using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controller;

public class AuthController(IAuthService userWriteService) : BaseController
{
    private readonly IAuthService _userService = userWriteService;

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn(UserSignInRequest request)
        => Ok(await _userService.SignIn(request));

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp(UserSignUpRequest request, CancellationToken token)
        => Ok(await _userService.SignUp(request, token));

    [HttpDelete("logout")]
    public IActionResult Logout()
    {
        _userService.Logout();
        return Ok();
    }

    [HttpGet("refresh")]
    public async Task<IActionResult> RefreshToken()
        => Ok(await _userService.RefreshToken());


    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(UserChangePasswordRequest request, CancellationToken token)
        => Ok(await _userService.ChangePassword(request, token));


    [HttpPut("update-profile")]
    [Authorize]
    public async Task<IActionResult> UpdateProfile(UserProfileUpdateRequest request, CancellationToken token)
    {
        return Ok(await _userService.UpdateProfile(request, token));
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> GetProfile()
        => Ok(await _userService.GetProfile());

    [HttpGet("check-token")]
    [Authorize]
    public IActionResult CheckToken()
    {
        return Ok(true);
    }
}
