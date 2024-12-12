using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Dashboard;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICountService
{
    Task<CountResponse> Show();
}
