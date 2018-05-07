using Microsoft.AspNetCore.Http;

namespace GameWeb.Models.Gallery
{
    public class UploadScreenshotModel
    {
        public string Title { get; set; }
        public string Tags { get; set; }
        public int GameId { get; set; }
        public IFormFile ScreenshotUpload { get; set; }
    }
}
