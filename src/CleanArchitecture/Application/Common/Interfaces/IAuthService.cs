using CleanArchitecture.Application.Common.Models.User;

namespace CleanArchitecture.Application.Common.Interfaces;
public interface IAuthService
{
    Task<UserSignInResponse> SignIn(UserSignInRequest request);
    Task<UserSignUpResponse> SignUp(UserSignUpRequest request, CancellationToken token);
    Task<UserProfileResponse> UpdateProfile(UserProfileUpdateRequest request, CancellationToken token);
    Task<UserProfileResponse> ChangePassword(UserChangePasswordRequest request, CancellationToken token);
    void Logout();
    Task<string> RefreshToken();
    Task<UserProfileResponse> GetProfile();
}
