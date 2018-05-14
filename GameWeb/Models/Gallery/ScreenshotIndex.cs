using System.Collections.Generic;

namespace GameWeb.Models.Gallery
{
    public class ScreenshotIndex
    {
        public IEnumerable<GalleryScreenshot> Screenshots { get; set; }
        public string SearchQuery { get; set; }
        public int GameId { get; set; }
    }
}