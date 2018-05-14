using System.Linq;
using GameWeb.Interfaces;
using GameWeb.Models.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameWeb.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IGames _games;

        public CatalogController(IGames games)
        {
            _games = games;
        }

        //public IActionResult Index()
        //{
        //    var gameModels = _games.GetAll();

        //    var listingResults = gameModels
        //        .Select(result => new Game
        //        {
        //            Id = result.Id,
        //            ImageUrl = result.ImageUrl,
        //            Title = result.Title,
        //            Genre = result.Genre,
        //            ReleaseYear = result.ReleaseYear,
        //            Rating = result.Rating,
        //            Platform = result.Platform

        //        });

        //    var model = new GameIndex()
        //    {
        //        Games = listingResults
        //    };

        //    return View(model);
        //}


        public IActionResult Index(string sortOption)
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

            var modelGames = listingResults.ToList();
            var model = new GameIndex
            {
                Games = modelGames
            };

            switch (sortOption)
            {
                case "Title":
                    model.Games = modelGames.OrderBy(game => game.Title);
                    break;
                case "Genre":
                    model.Games = modelGames.OrderBy(game => game.Genre);
                    break;
                case "Platform":
                    model.Games = modelGames.OrderBy(game => game.Rating);
                    break;
                case "ReleaseYear":
                    model.Games = modelGames.OrderByDescending(game => game.ReleaseYear);
                    break;
                case "Rating":
                    model.Games = modelGames.OrderByDescending(game => game.Rating);
                    break;
                default:
                    model.Games = modelGames;
                    break;
            }

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
            return RedirectToAction("Index", "ScreenshotGallery", new
            {
                id
            });
        }

        public IActionResult SearchGames(string searchPattern)
        {
            //Matching all letters to lowercase (the same thing is happening to game title during comparison)
            searchPattern = searchPattern.ToLower();

            var games = _games.GetAll();

            if (!string.IsNullOrEmpty(searchPattern))
                games = games.Where(game => game.Title.ToLower().Contains(searchPattern));

            var listingResults = games
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

            var modelGames = listingResults.ToList();
            var model = new GameIndex
            {
                Games = modelGames
            };

            return View(model);
        }
    }
}