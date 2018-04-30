using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}