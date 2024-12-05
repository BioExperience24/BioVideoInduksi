using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Web.Requests;

public class PublishRequestUpdate : PublishRequest
{
    [Required]
    public int Id { get; set; }
}
