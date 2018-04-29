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
        public IActionResult Index()
        {
            var godOfWarFightTags = new List<ScreenshotTag>();
            var godOfWarExplorationTags = new List<ScreenshotTag>();

            var tag1 = new ScreenshotTag
            {
                Description = "Fight",
                Id = 0
            };

            var tag2 = new ScreenshotTag
            {
                Description = "Tough",
                Id = 1
            };

            var tag3 = new ScreenshotTag
            {
                Description = "Landscape",
                Id = 2
            };

            godOfWarFightTags.AddRange(new List<ScreenshotTag>{tag1, tag2});
            godOfWarExplorationTags.Add(tag3);

            var screenshotList = new List<GalleryScreenshot>
            {
                new GalleryScreenshot()
                {
                    Title = "God of War Fight",
                    Url = "https://artfiles.alphacoders.com/112/112217.jpg",
                    Created = DateTime.Now,
                    Tags = godOfWarFightTags
                },

                new GalleryScreenshot()
                {
                    Title = "God of War Landscape",
                    Url = "https://cdn.gamer-network.net/2018/usgamer/god-of-war-atreus-kratos-landscape.jpg",
                    Created = DateTime.Now,
                    Tags = godOfWarExplorationTags
                },

                new GalleryScreenshot()
                {
                    Title = "God of War Exploration",
                    Url = "http://cdn.escapistmagazine.com/media/global/images/library/deriv/1309/1309079.jpg",
                    Created = DateTime.Now,
                    Tags = godOfWarExplorationTags
                }
            };

            var model = new ScreenshotIndex
            {
                Screenshots = screenshotList,
                SearchQuery = String.Empty
            };
            return View(model);
        }
    }
}