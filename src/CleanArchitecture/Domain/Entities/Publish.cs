using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Application.Common.Models;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Domain.Entities;

public class Publish : BaseModel
{
    public DateTime? PublishDate {get; set;} = DateTime.Now;

    public string PublishType { get; set; }
    
    public DateTime? StartTime { get; set; }
    
    public DateTime? EndTime { get; set; }
    
    public string Status { get; set; } = string.Empty;
    
    public int? PlayerId { get; set; }

    [ForeignKey(nameof(PlayerId))]
    [JsonIgnore]
    public Player? Player { get; set; }

    public int? SignageId { get; set; }

    [ForeignKey(nameof(SignageId))]
    public Signage? Signage { get; set; }
    
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    
    public DateTime? DeletedAt { get; set; } = null;
}