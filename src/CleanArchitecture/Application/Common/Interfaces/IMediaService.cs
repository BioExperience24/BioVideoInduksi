using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Media;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IMediaService
{
    Task<Pagination<Media>> GetAll(int pageIndex, int pageSize);
    Task<ApiCollection<Media>> GetCollection(int pageIndex, int pageSize);
    Task<Media> Get(int id);
    Task Add(MediaRequest request, CancellationToken token);
    Task Update(MediaRequestUpdate request, CancellationToken token);
    Task Delete(int id, CancellationToken token);
}
