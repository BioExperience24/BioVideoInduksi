using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.Media;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using MediaToolkit;


namespace CleanArchitecture.Application.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IConfiguration _configuration;

        public FileUploadService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UploadFileResult> UploadFileAsync(IFormFile file, CancellationToken token)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or not provided.");
            }

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration["UploadSettings:Directory"]);

            // Pastikan direktori upload ada
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Buat nama file unik untuk menghindari duplikasi
            var tempFilename = Path.GetFileName(file.FileName);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(tempFilename);
            var fileUploadPath = Path.Combine(uploadFolder, fileName);
            var relativePath = Path.Combine("/uploads", fileName).Replace("\\", "/");

            // Simpan file ke disk
            using (var fileStream = new FileStream(fileUploadPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream, token);
            }

            // tipe file
            var mediaType = GetMediaTypeFromContentType(file.ContentType);

            // ukuran file
            string fileSize = (file.Length / (1024.0 * 1024.0)).ToString("F2");

            // durasio video
            string duration = string.Empty;
            if (mediaType == MediaType.Video)
            {
                duration = GetVideoDuration(fileUploadPath);
            }

            return new UploadFileResult
            {
                FilePath = relativePath,
                MediaType = mediaType ?? MediaType.Image,
                Duration = duration,
                FileSize = fileSize
            };
        }

        public async Task DeleteFileAsync(string relativePath, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                throw new ArgumentException("File path is not provided or empty.", nameof(relativePath));
            }

            // Dapatkan direktori upload dari konfigurasi
            var uploadDirectory = Path.GetFullPath(_configuration["UploadSettings:Directory"], Directory.GetCurrentDirectory());

            if (relativePath.StartsWith("/uploads", StringComparison.OrdinalIgnoreCase))
            {
                relativePath = relativePath.Substring("/uploads".Length).TrimStart('/');
            }

            // Konversi path relatif menjadi path absolut
            var absolutePath = Path.Combine(uploadDirectory, relativePath).Replace("/", Path.DirectorySeparatorChar.ToString());

            // Console.WriteLine("+========================+");
            // Console.WriteLine($"Absolute Path: {absolutePath}");
            // Console.WriteLine("+========================+");

            // Periksa apakah file ada dan hapus
            if (File.Exists(absolutePath))
            {
                try
                {
                    File.Delete(absolutePath); // Menghapus file
                    await Task.CompletedTask; // Tandai sebagai selesai
                }
                catch (Exception ex)
                {
                    // Tangani error
                    throw new InvalidOperationException($"Failed to delete file at {absolutePath}.", ex);
                }
            }
        }


        public MediaType? GetMediaTypeFromContentType(string contentType)
        {
            return contentType switch
            {
                "image/jpeg" or "image/png" => MediaType.Image,
                "video/mp4" or "video/mpeg" => MediaType.Video,
                _ => null // Return null for unsupported types
            };
        }

        private static string GetVideoDuration(string filePath)
        {
            try
            {
                // Menggunakan MediaToolkit untuk membaca metadata video
                using var engine = new MediaToolkit.Engine();
                var inputFile = new MediaToolkit.Model.MediaFile { Filename = filePath };

                // Dapatkan metadata file
                engine.GetMetadata(inputFile);

                // Ambil durasi dari metadata
                var duration = inputFile.Metadata.Duration;

                // Format durasi ke string dalam format hh:mm:ss
                return duration.ToString(@"hh\:mm\:ss");
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
