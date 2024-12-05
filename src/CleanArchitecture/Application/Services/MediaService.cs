using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Media;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Application.Services;

public class MediaService(
    IUnitOfWork unitOfWork,
    IFileUploadService fileUploadService,
    IConfiguration configuration
) : IMediaService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IConfiguration _configuration = configuration;
    private readonly IFileUploadService _fileUploadService = fileUploadService;

    public async Task<Pagination<Media>> GetAll(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.MediaRepository.ToPagination(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true
            );

        return data;
    }

    public async Task<ApiCollection<Media>> GetCollection(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.MediaRepository.ToAllResult(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true,
            filter: x => x.DeletedAt == null
            );

        return data;
    }

    public async Task<Media> Get(int id)
    {
        var data = await _unitOfWork.MediaRepository.FirstOrDefaultAsync(x => x.Id == id);
        return data;
    }

    public async Task Add(MediaRequest request, CancellationToken token)
    {
        var file = await _fileUploadService.UploadFileAsync(request.MediaFile, token);

        var media = new Media
        {
            Name = request.Name,
            Filename = file.FileName,
            Path = file.FilePath,
            Size = file.FileSize,
            MediaType = file.MediaType,
            Duration = file.Duration
        };

        await _unitOfWork.ExecuteTransactionAsync(async () =>
        {
            await _unitOfWork.MediaRepository.AddAsync(media);
        }, token);
    }

    public async Task Update(MediaRequestUpdate request, CancellationToken token)
    {
        var data = await _unitOfWork.MediaRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

        // Perbarui data
        data.Name = request.Name;

        // Jika ada file baru, lakukan proses upload
        if (request.MediaFile != null)
        {
            // Lokasi file lama
            var oldFilePath = data.Path;

            // Upload file baru
            var file = await _fileUploadService.UploadFileAsync(request.MediaFile, token);

            // Perbarui data file di entitas
            data.Filename = file.FileName;
            data.Path = file.FilePath;
            data.Size = file.FileSize;
            data.Duration = file.Duration;
            data.MediaType = file.MediaType;

            // Transaksi database untuk update data
            await _unitOfWork.ExecuteTransactionAsync(() =>
            {
                _unitOfWork.MediaRepository.Update(data);
            }, token);

            // Hapus file lama setelah transaksi berhasil
            await _fileUploadService.DeleteFileAsync(oldFilePath, token);
        }
        else
        {
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.MediaRepository.Update(data), token);
        }
    }

    public async Task Delete(int id, CancellationToken token)
    {
        var data = await _unitOfWork.MediaRepository.FirstOrDefaultAsync(x => x.Id == id);

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.MediaRepository.Delete(data), token);

        // remove file
        _fileUploadService.DeleteFileAsync(data.Path, token);
    }
}
