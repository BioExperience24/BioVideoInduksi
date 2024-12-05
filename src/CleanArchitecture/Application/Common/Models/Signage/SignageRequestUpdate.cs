using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Common.Models.Signage;

public class SignageRequestUpdate : SignageRequest
{
    [Required]
    public int Id { get; set; }
}
