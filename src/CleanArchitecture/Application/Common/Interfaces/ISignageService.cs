using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Signage;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ISignageService
{
    Task<Pagination<Signage>> GetAll(int pageIndex, int pageSize);
    Task<ApiCollection<Signage>> GetCollection(int pageIndex, int pageSize);
    Task<Signage> Get(int id);
    Task Add(SignageRequestAdd request, CancellationToken token);
    Task Update(SignageRequestUpdate request, CancellationToken token);
    Task Delete(int id, CancellationToken token);
}
