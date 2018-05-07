using System;
using System.Linq;
using GameWeb.Interfaces;
using GameWeb.Models;
using GameWeb.Models.Gallery;
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

        //Following Action is displaying gallery of all screenshots ---> TO DO: implement this to button (Show Gallery or something)
        //public IActionResult Index()
        //{
        //    var screenshotList = _galleryService.GetAll();

        //    var model = new ScreenshotIndex
        //    {
        //        Screenshots = screenshotList,
        //        SearchQuery = String.Empty
        //    };
        //    return View(model);
        //}

        public IActionResult Index(int id)
        {
            var screenshotList = _galleryService.GetAllByGameId(id);

            var model = new ScreenshotIndex
            {
                Screenshots = screenshotList,
                GameId = id,
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

        public IActionResult RedirectGameId(int id)
        {
            return RedirectToAction("Upload", "Screenshot", new
            {
                id
            });
        }
    }
}