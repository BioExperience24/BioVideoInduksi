using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Requests;

public abstract class PlayerRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Serial { get; set; }

    [Required]
    public int PlayerGroupId { get; set; }
}