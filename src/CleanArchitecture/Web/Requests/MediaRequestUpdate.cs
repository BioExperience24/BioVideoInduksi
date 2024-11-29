using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Web.Requests;

public class MediaRequestUpdate
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public IFormFile? MediaFile { get; set; }
}
