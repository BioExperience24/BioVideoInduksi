using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Common.Models.Template;

public class TemplateResponse : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public string Resolution { get; set; } = string.Empty;
    public string Scale { get; set; } = string.Empty;
    public string Orientation { get; set; } = string.Empty;
    public string Layout { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
}