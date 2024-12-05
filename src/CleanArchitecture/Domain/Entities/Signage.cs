using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Domain.Entities;

public class Signage : BaseModel
{
    public string Name { get; set; } = string.Empty;

    [Column(TypeName="ntext")]
    [MaxLength]
    public string Content { get; set; } = string.Empty;
    public int? TemplateId { get; set; }

    [ForeignKey(nameof(TemplateId))]
    public Template? Template { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
}
