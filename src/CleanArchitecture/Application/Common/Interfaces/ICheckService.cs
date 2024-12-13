using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICheckService
{
    Task<object> Show(string serial, CancellationToken token);
}
