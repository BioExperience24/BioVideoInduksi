using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Requests;

public class PlayerGroupUpdateRequest : PlayerGroupRequest
{
    [Required]
    public int Id { get; set; }
}
