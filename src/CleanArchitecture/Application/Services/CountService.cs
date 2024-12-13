using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Dashboard;


namespace CleanArchitecture.Application.Services;

public class CountService : ICountService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileUploadService _fileUploadService;

    public CountService(IUnitOfWork unitOfWork, IFileUploadService fileUploadService)
    {
        _unitOfWork = unitOfWork;
        _fileUploadService = fileUploadService;
    }

    public async Task<CountResponse> Show()
    {
        var now = DateTime.UtcNow;
        var before3Minutes = now.AddMinutes(-3);

        return new CountResponse
        {
            Player = await _unitOfWork.PlayerRepository.CountAsync(x => x.DeletedAt == null),
            Signage = await _unitOfWork.SignageRepository.CountAsync(x => x.DeletedAt == null),
            PlayerLive = await _unitOfWork.PlayerRepository.CountAsync(
                x => x.DeletedAt == null &&
                     x.PlayerLiveAt != null && 
                     x.PlayerLiveAt >= before3Minutes
            ),
            StorageUsage = _fileUploadService.GetStorageUsage()
        };
    }
}