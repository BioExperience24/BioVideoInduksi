using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Common.Models.Signage;

public abstract class SignageRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int TemplateId { get; set; } = 0;

    [Required]
    public int[] MediaIds { get; set; } = null!;

    [Required]
    public string RunningText { get; set; }

    [Required]
    public string TextColor { get; set; }

    [Required]
    public string BackgroundColor { get; set; }

    [Required]
    public int FontSize { get; set; }

    [Required]
    public int TextSpeed { get; set; }
}
