using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Publish;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Services;

public class PublishService(IUnitOfWork unitOfWork) : IPublishService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Pagination<Publish>> GetAll(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.PublishRepository.ToPagination(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.PublishDate,
            ascending: true
        );

        return data;
    }

    public async Task<ApiCollection<Publish>> GetCollection(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.PublishRepository.ToAllResult(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.PublishDate,
            ascending: true,
            filter: x => x.DeletedAt == null,
            include: query => query.Include(x => x.Player).Include(x => x.Signage)
        );

        return data;
    }

    public async Task<Publish> Get(int id)
    {
        var data = await _unitOfWork.PublishRepository.FirstOrDefaultAsync(
            x => x.Id == id,
            include: x => x.Include(x => x.Player).Include(x => x.Signage)
        );

        return data;
    }

    public async Task Add(PublishRequestAdd request, CancellationToken token)
    {
        var Publish = new Publish
        {
            PublishDate = request.PublishDate,
            PublishType = request.PublishType,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Status = request.Status,
            PlayerId = request.PlayerId,
            SignageId = request.SignageId
        };

        await _unitOfWork.ExecuteTransactionAsync(async () =>
        {
            await _unitOfWork.PublishRepository.AddAsync(Publish);
        }, token);
    }

    public async Task Update(PublishRequestUpdate request, CancellationToken token)
    {
        var data = await _unitOfWork.PublishRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

        data.PublishDate = request.PublishDate;
        data.PublishType = request.PublishType;
        data.StartTime = request.StartTime;
        data.EndTime = request.EndTime;
        data.Status = request.Status;
        data.PlayerId = request.PlayerId;
        data.SignageId = request.SignageId;

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PublishRepository.Update(data), token);
    }

    public async Task Delete(int id, CancellationToken token)
    {
        var data = await _unitOfWork.PublishRepository.FirstOrDefaultAsync(x => x.Id == id);

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PublishRepository.Delete(data), token);
    }
}
