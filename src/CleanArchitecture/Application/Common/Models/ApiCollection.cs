namespace CleanArchitecture.Application.Common.Models;

public class ApiCollection<T>
{
    
    public int Count { get; set; } = 0;
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 0;
    public string Status { get; set; } = "success";
    public ICollection<T>? Collection { get; set; }
}
