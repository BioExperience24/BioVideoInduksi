using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.PlayerGroup;
using CleanArchitecture.Application.Common.Models.Publish;

namespace CleanArchitecture.Application.Common.Models.Player;

public class PlayerResponse : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Serial { get; set; } = string.Empty;
    public int PlayerGroup_Id { get; set; } = 0;
    public PlayerGroupResponse? PlayerGroup { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? PlayerLiveAt { get; set; }
}
