using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Publish;
using CleanArchitecture.Application.Common.Models.Player;
using CleanArchitecture.Application.Common.Models.PlayerGroup;
using CleanArchitecture.Application.Common.Models.Signage;
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

    public async Task<ApiCollection<PublishResponse>> GetCollection(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.PublishRepository.ToAllResult(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.PublishDate,
            ascending: true,
            filter: x => x.DeletedAt == null,
            include: query => query.Include(x => x.Player).Include(x => x.Signage)
        );

        var response = data.Collection.Select(publish => new PublishResponse
        {
            Id = publish.Id,
            PublishDate = publish.PublishDate,
            PublishType = publish.PublishType,
            Status = publish.Status,
            CreatedAt = publish.CreatedAt,
            UpdatedAt = publish.UpdatedAt,
            PlayerData = publish.Player != null ? new PlayerResponse
            {
                Id = publish.Player.Id,
                Name = publish.Player.Name,
                Serial = publish.Player.Serial,
                PlayerGroup_Id = publish.Player.PlayerGroupId ?? 0,
                PlayerLiveAt = publish.Player.PlayerLiveAt
            } : null,
            Signage = publish.Signage != null ? new SignageResponse
            {
                Id = publish.Signage.Id,
                Name = publish.Signage.Name
            } : null
        }).ToList();

        return new ApiCollection<PublishResponse>
        {
            Count = data.Count,
            PageIndex = data.PageIndex,
            PageSize = data.PageSize,
            Collection = response
        };
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
        var publishDateUtc = request.PublishDate.ToUniversalTime();

        var Publish = new Publish
        {
            PublishDate = publishDateUtc, // Simpan dalam UTC
            PublishType = request.PublishType,
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

        if (data == null)
        {
            throw new KeyNotFoundException("Data not found.");
        }

        // Konversi PublishDate ke UTC jika ada
        data.PublishDate = request.PublishDate.ToUniversalTime();

        // Properti lain tidak memerlukan konversi
        data.PublishType = request.PublishType;
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
