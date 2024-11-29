using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Domain.Entities;

public class Publish : BaseModel
{
    public DateTime? PublishDate {get; set;} = DateTime.Now;
    public PublishType PublishType { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public Player? Player_Id { get; set; }
    public Signage? Signage_Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
}
