using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWeb.Models
{
    public class ScreenshotIndex
    {
        public IEnumerable<GalleryScreenshot> Screenshots { get; set; }
        public string SearchQuery { get; set; }
        public int GameId { get; set; }
    }
}
