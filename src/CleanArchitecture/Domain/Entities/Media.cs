using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Domain.Entities;

public class Media : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Filename { get; set; } = string.Empty;
    public MediaType? MediaType { get; set; } = null;
    public string Size { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; } = null;
}
