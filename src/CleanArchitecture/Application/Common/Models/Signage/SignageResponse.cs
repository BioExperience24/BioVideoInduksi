using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Template;

namespace CleanArchitecture.Application.Common.Models.Signage;

public class SignageResponse : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int TemplateId { get; set; } = 0;
    public TemplateResponse? Template { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; } = null;
}