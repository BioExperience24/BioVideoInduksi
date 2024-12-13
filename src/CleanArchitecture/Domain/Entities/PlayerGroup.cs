using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Domain.Entities;

public class PlayerGroup : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; } = null;
}
