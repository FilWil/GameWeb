using GameWeb.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWeb
{
    public interface IScreenshot
    {
        IEnumerable<GalleryScreenshot> GetAll();
        IEnumerable<GalleryScreenshot> GetByTagName(string tag);
        GalleryScreenshot GetById(int id);
        CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
        Task SetScreenshot(string title, string tags, Uri uri);
        List<ScreenshotTag> ParseTags(string tags);

    }
}
