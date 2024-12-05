using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Requests;

public abstract class PublishRequest
{
    [Required]
    public DateTime PublishDate { get; set; }

    [Required]
    public string PublishType { get; set; }
    
    public DateTime? StartTime { get; set; } = DateTime.UtcNow;
    
    public DateTime? EndTime { get; set; } = DateTime.UtcNow;
    
    [Required]
    public string Status { get; set; }
    
    [Required]
    public int PlayerId { get; set; }
    
    [Required]
    public int SignageId { get; set; }
}