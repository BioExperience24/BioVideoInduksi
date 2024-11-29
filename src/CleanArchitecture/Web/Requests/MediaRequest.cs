using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Web.Requests;

public class MediaRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public IFormFile? MediaFile { get; set; }
}
