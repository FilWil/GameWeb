using System;
using System.Linq;
using GameWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameWeb.Controllers
{
    public class ScreenshotGalleryController : Controller
    {
        private readonly IScreenshot _galleryService;

        //Dependency injection of IScreenshot interface through constructor
        public ScreenshotGalleryController(IScreenshot galleryService)
        {
            _galleryService = galleryService;
        }

        public IActionResult Index()
        {
            var screenshotList = _galleryService.GetAll();

            var model = new ScreenshotIndex
            {
                Screenshots = screenshotList,
                SearchQuery = String.Empty
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var screenshot = _galleryService.GetById(id);

            var model = new GalleryDetailModel
            {
                Id = screenshot.Id,
                Title = screenshot.Title,
                Created = screenshot.Created,
                Url = screenshot.Url,
                Tags = screenshot.Tags.Select(t => t.Description).ToList()
            };

            return View(model);
        }
    }
}