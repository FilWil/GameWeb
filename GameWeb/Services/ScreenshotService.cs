using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWeb.Data;
using GameWeb.Interfaces;
using GameWeb.Models.Gallery;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace GameWeb.Services
{
    public class ScreenshotService : IScreenshot
    {
        private readonly ApplicationDbContext _context;

        public ScreenshotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GalleryScreenshot> GetAll()
        {
            return _context.GalleryScreenshots
                .Include(screenshot => screenshot.Tags);
        }

        public IEnumerable<GalleryScreenshot> GetAllByGameId(int gameId)
        {
            return GetAll().Where(screenshot => screenshot.GameId == gameId);
        }

        public GalleryScreenshot GetById(int id)
        {
            return GetAll().First(screenshot => screenshot.Id == id);
        }

        public IEnumerable<GalleryScreenshot> GetByTagName(string tag)
        {
            return GetAll().Where(screenshot => screenshot.Tags.Any(t => t.Description == tag));
        }

        public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient.GetContainerReference(containerName);
        }

        public async Task SetScreenshot(string title, int gameId, string tags, Uri uri)
        {
            var screenshot = new GalleryScreenshot
            {
                Title = title,
                Tags = ParseTags(tags),
                GameId = gameId,
                Url = uri.AbsoluteUri,
                Created = DateTime.Now
            };

            _context.Add(screenshot);
            await _context.SaveChangesAsync();
        }

        public List<ScreenshotTag> ParseTags(string tags)
        {
            return tags.Split(",")
                .Select(tag => new ScreenshotTag {Description = tag})
                .ToList();
        }
    }
}