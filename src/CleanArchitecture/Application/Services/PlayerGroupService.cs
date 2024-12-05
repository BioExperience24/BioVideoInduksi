using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.PlayerGroup;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Services;

public class PlayerGroupService(
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IPlayerGroupService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Pagination<PlayerGroup>> GetAll(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.PlayerGroupRepository.ToPagination(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true
        );

        return data;
    }

    public async Task<ApiCollection<PlayerGroup>> GetCollection(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.PlayerGroupRepository.ToAllResult(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true,
            filter: x => x.DeletedAt == null
            );

        return data;
    }

    public async Task<PlayerGroup> Get(int id)
    {
        var data = await _unitOfWork.PlayerGroupRepository.FirstOrDefaultAsync(x => x.Id == id);
        return data;
    }

    public async Task Add(PlayerGroupAddRequest request, CancellationToken token)
    {
        var playerGroup = new PlayerGroup
        {
            Name = request.Name
        };

        await _unitOfWork.ExecuteTransactionAsync(async () =>
        {
            await _unitOfWork.PlayerGroupRepository.AddAsync(playerGroup);
        }, token);
    }

    public async Task Update(PlayerGroupUpdateRequest request, CancellationToken token)
    {
        var data = await _unitOfWork.PlayerGroupRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

        data.Name = request.Name;
        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PlayerGroupRepository.Update(data), token);
    }

    public async Task Delete(int id, CancellationToken token)
    {
        var data = await _unitOfWork.PlayerGroupRepository.FirstOrDefaultAsync(x => x.Id == id);

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PlayerGroupRepository.Delete(data), token);
    }
}
