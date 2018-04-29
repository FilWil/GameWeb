using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWeb.Models
{
    public class GalleryScreenshot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Url { get; set; } //for Microsoft Azure
        public virtual IEnumerable<ScreenshotTag> Tags { get; set; }
    }
}
