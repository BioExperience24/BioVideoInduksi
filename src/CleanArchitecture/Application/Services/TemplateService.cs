using AutoMapper;

using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Template;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Services;

public class TemplateService(IUnitOfWork unitOfWork) : ITemplateService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Pagination<Template>> GetAll(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.TemplateRepository.ToPagination(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true
        );

        return data;
    }

    public async Task<ApiCollection<Template>> GetCollection(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.TemplateRepository.ToAllResult(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true,
            filter: x => x.DeletedAt == null
        );

        return data;
    }

    public async Task<Template> Get(int id)
    {
        return await _unitOfWork.TemplateRepository.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(TemplateRequestUpdate request, CancellationToken token)
    {
        var data = await _unitOfWork.TemplateRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

        data.Name = request.Name;

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.TemplateRepository.Update(data), token);
    }
}
