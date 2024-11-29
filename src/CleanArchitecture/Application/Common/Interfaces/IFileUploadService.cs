using CleanArchitecture.Application.Common.Models;


namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IFileUploadService
    {
        Task<UploadFileResult> UploadFileAsync(IFormFile file, CancellationToken token);

        MediaType? GetMediaTypeFromContentType(string contentType);

        Task DeleteFileAsync(string filePath, CancellationToken token); 
    }
}
