using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Domain.Entities;

public class Template : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Resolution { get; set; } = string.Empty;
    public string Scale { get; set; } = string.Empty;
    public string Orientation { get; set; } = string.Empty;
    [Column(TypeName="ntext")]
    [MaxLength]
    public string Layout { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; } = null;
}
