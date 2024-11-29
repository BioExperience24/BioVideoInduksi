namespace CleanArchitecture.Application.Common.Models
{
    public class UploadFileResult
    {
        public string FilePath { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
        public string Duration { get; set; } = string.Empty;
        public string FileSize { get; set; }
    }
}
