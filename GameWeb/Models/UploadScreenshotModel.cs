using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWeb.Models
{
    public class UploadScreenshotModel
    {
        public string Title { get; set; }
        public string Tags { get; set; }
        public int GameId { get; set; }
        public IFormFile ScreenshotUpload { get; set; }
    }
}
