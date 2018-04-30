using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameWeb.Data;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Services
{
    public class ScreenshotService : IScreenshot
    {
        private ApplicationDbContext _context;

        public ScreenshotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GalleryScreenshot> GetAll()
        {
            return _context.GalleryScreenshots
                .Include(screenshot => screenshot.Tags);
        }

        public GalleryScreenshot GetById(int id)
        {
            return _context.GalleryScreenshots.Find(id);
        }

        public IEnumerable<GalleryScreenshot> GetByTagName(string tag)
        {
            return GetAll().Where(screenshot => screenshot.Tags.Any(t => t.Description == tag));
        }
    }
}
