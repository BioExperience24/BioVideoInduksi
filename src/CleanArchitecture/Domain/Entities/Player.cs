using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Domain.Entities;

public class Player : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Serial { get; set; } = string.Empty;
    public int? PlayerGroupId { get; set; }

    [ForeignKey(nameof(PlayerGroupId))]
    public PlayerGroup? PlayerGroup { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; } = null;
    public DateTime? PlayerLiveAt { get; set; } = null;
}
