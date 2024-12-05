using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Requests;

public class PlayerUpdateRequest : PlayerRequest
{
    [Required]
    public int Id { get; set; }
}
