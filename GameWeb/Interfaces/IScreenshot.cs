using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameWeb.Models.Gallery;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GameWeb.Interfaces
{
    public interface IScreenshot
    {
        IEnumerable<GalleryScreenshot> GetAll();
        IEnumerable<GalleryScreenshot> GetAllByGameId(int gameId);
        IEnumerable<GalleryScreenshot> GetByTagName(string tag);
        GalleryScreenshot GetById(int id);
        CloudBlobContainer GetBlobContainer(string connectionString, string containerName);
        Task SetScreenshot(string title, int gameId, string tags, Uri uri);
        List<ScreenshotTag> ParseTags(string tags);
    }
}
