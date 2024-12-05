using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Requests;

public abstract class PlayerGroupRequest
{
    [Required]
    public string Name { get; set; }
}
