using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Template;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ITemplateService
{
    Task<Pagination<Template>> GetAll(int pageIndex, int pageSize);
    Task<ApiCollection<Template>> GetCollection(int pageIndex, int pageSize);
    Task<Template> Get(int id);
    Task Update(TemplateRequestUpdate request, CancellationToken token);
}
