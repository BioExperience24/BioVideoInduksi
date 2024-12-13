using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Publish;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IPublishService
{
    Task<Pagination<Publish>> GetAll(int pageIndex, int pageSize);
    Task<ApiCollection<PublishResponse>> GetCollection(int pageIndex, int pageSize);
    Task<Publish> Get(int id);
    Task Add(PublishRequestAdd request, CancellationToken token);
    Task Update(PublishRequestUpdate request, CancellationToken token);
    Task Delete(int id, CancellationToken token);
}
