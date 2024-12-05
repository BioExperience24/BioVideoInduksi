using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Common.Models.PlayerGroup;

public class PlayerGroupResponse : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
}
