using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Common.Models.Dashboard;

public class CountResponse
{
    public int Signage { get; set; }
    public int Player { get; set; }
    public int PlayerLive { get; set; }
    public string StorageUsage { get; set; }
}
