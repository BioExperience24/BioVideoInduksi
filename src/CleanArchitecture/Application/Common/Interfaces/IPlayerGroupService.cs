using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.PlayerGroup;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IPlayerGroupService
{
    Task<Pagination<PlayerGroup>> GetAll(int pageIndex, int pageSize);
    Task<ApiCollection<PlayerGroup>> GetCollection(int pageIndex, int pageSize);
    Task<PlayerGroup> Get(int id);
    Task Add(PlayerGroupAddRequest request, CancellationToken token);
    Task Update(PlayerGroupUpdateRequest request, CancellationToken token);
    Task Delete(int id, CancellationToken token);
}
