using System;
using System.Collections.Generic;

namespace GameWeb.Models.Gallery
{
    public class GalleryScreenshot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; } //for Microsoft Azure
        public virtual IEnumerable<ScreenshotTag> Tags { get; set; }
        public int GameId { get; set; }
    }
}
