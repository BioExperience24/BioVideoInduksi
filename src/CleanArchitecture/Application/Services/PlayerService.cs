using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Player;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Services;

public class PlayerService(
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IPlayerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Pagination<Player>> GetAll(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.PlayerRepository.ToPagination(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true
        );

        return data;
    }

    public async Task<ApiCollection<Player>> GetCollection(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.PlayerRepository.ToAllResult(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true,
            filter: x => x.DeletedAt == null,
            include: query => query
                .Include(x => x.PlayerGroup)
        );

       return data;
    }

    public async Task<Player> Get(int id)
    {
        var data = await _unitOfWork.PlayerRepository.FirstOrDefaultAsync(x => x.Id == id, include: x => x.Include(x => x.PlayerGroup));

        if (data == null)
        {
            throw new Exception("Player not found");
        }

        return data;
    }

    public async Task Add(PlayerAddRequest request, CancellationToken token)
    {
        var Player = new Player
        {
            Name = request.Name,
            Serial = request.Serial,
            PlayerGroupId = request.PlayerGroupId
        };

        await _unitOfWork.ExecuteTransactionAsync(async () =>
        {
            await _unitOfWork.PlayerRepository.AddAsync(Player);
        }, token);
    }

    public async Task Update(PlayerUpdateRequest request, CancellationToken token)
    {
        var data = await _unitOfWork.PlayerRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

        data.Name = request.Name;
        data.Serial = request.Serial;
        data.PlayerGroupId = request.PlayerGroupId;

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PlayerRepository.Update(data), token);
    }

    public async Task Delete(int id, CancellationToken token)
    {
        var data = await _unitOfWork.PlayerRepository.FirstOrDefaultAsync(x => x.Id == id);

        data.DeletedAt = DateTime.UtcNow;

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PlayerRepository.Update(data), token);
    }
}
