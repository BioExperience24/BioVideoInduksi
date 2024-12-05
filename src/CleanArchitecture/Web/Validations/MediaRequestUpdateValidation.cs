using FluentValidation;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Web.Requests;

namespace CleanArchitecture.Web.Validations
{
    public class MediaRequestUpdateValidation : AbstractValidator<MediaRequestUpdate>
    {
        public MediaRequestUpdateValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(100)
                .WithMessage("Name must not exceed 100 characters.");

            // Validasi file hanya ketika ada file baru yang diupload
            RuleFor(x => x.MediaFile)
                .Must(BeValidFileSize)
                .WithMessage("File size is invalid.")
                .Must(BeValidFileExtension)
                .WithMessage("File extension is invalid.")
                .When(x => x.MediaFile != null);  // Validasi hanya jika file ada
        }

        private bool BeValidFileSize(IFormFile file)
        {
            if (file == null) return false;

            var contentType = file.ContentType.ToLower();

            if (contentType.StartsWith("image"))
            {
                return file.Length <= 5 * 1024 * 1024; // 5 MB untuk gambar
            }
            else if (contentType.StartsWith("video"))
            {
                return file.Length <= 1L * 1024 * 1024 * 1024; // 1 GB untuk video
            }

            return false;
        }


        private bool BeValidFileExtension(IFormFile file)
        {
            if (file == null) return false;

            var contentType = file.ContentType.ToLower();

            if (contentType.StartsWith("image"))
            {
                return file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".png") || file.FileName.EndsWith(".jpeg");
            }
            else if (contentType.StartsWith("video"))
            {
                return file.FileName.EndsWith(".mp4");
            }

            return false;
        }
    }
}
