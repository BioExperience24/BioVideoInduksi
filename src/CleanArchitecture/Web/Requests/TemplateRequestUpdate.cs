using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Requests;

public class TemplateRequestUpdate
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
