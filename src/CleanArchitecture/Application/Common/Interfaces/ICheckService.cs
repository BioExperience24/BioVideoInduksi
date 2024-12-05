using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Player;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICheckService
{
    Task<object> Show(string serial);
}
