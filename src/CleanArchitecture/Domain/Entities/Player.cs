using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Domain.Entities;

public class Player : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Serial { get; set; } = string.Empty;
    public PlayerGroup? PlayerGroup_Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
}
