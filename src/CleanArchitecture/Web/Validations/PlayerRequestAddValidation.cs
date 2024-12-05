using FluentValidation;
using CleanArchitecture.Web.Requests;

public class PlayerRequestAddValidation : PlayerRequestValidation<PlayerAddRequest>
{
    public PlayerRequestAddValidation()
    {
    }
}
