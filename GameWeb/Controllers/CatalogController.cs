using System.Linq;
using GameWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameWeb.Controllers
{
    public class CatalogController : Controller
    {
        private IGames _games;
        public CatalogController(IGames games)
        {
            _games = games;
        }

        public IActionResult Index()
        {
            var gameModels = _games.GetAll();

            var listingResults = gameModels
                .Select(result => new Game
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    Title = result.Title,
                    Genre = result.Genre,
                    ReleaseYear = result.ReleaseYear,
                    Rating = result.Rating,
                    Platform = result.Platform

                });

            var model = new GameIndex()
            {
                Games = listingResults
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var game = _games.GetById(id);
            var model = new GameDetail
            {
                GameId = id,
                Title = game.Title,
                Genre = game.Genre,
                ImageUrl = game.ImageUrl,
                Platform = game.Platform,
                Rating = game.Rating,
                ReleaseYear = game.ReleaseYear
            };
            return View(model);
        }

        public IActionResult RedirectGameIdToGallery(int id)
        {
            return RedirectToAction("Index", "ScreenshotGallery", new {
                id
            });
        }
    }
}