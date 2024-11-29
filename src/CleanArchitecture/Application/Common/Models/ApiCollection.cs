namespace CleanArchitecture.Application.Common.Models;

public class ApiCollection<T>
{
    
    public int Count { get; set; } = 0;
    public string Status { get; set; } = "success";
    public ICollection<T>? Collection { get; set; }
}
