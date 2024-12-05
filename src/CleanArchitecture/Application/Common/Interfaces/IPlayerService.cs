using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Player;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IPlayerService
{
    Task<Pagination<Player>> GetAll(int pageIndex, int pageSize);
    Task<ApiCollection<Player>> GetCollection(int pageIndex, int pageSize);
    Task<Player> Get(int id);
    Task Add(PlayerAddRequest request, CancellationToken token);
    Task Update(PlayerUpdateRequest request, CancellationToken token);
    Task Delete(int id, CancellationToken token);
}
