namespace CleanArchitecture.Application.Common.Models.User;

public class UserChangePasswordRequest
{
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}
