using System.Net.Http.Headers;
using System.Threading.Tasks;
using GameWeb.Interfaces;
using GameWeb.Models.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GameWeb.Controllers
{
    public class GameController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IGames _gamesService;

        public GameController(IConfiguration config, IGames gamesService)
        {
            _config = config;
            _gamesService = gamesService;
            AzureConnectionString = _config["AzureStorageConnectionString"];
        }

        private string AzureConnectionString { get; }

        public IActionResult AddGame()
        {
            var model = new AddGame();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewGame(IFormFile file, string title, string genre, string platform,
            int releaseYear)
        {
            var container = _gamesService.GetBlobContainer(AzureConnectionString, "games");

            var content =
                ContentDispositionHeaderValue.Parse(file
                    .ContentDisposition); //TO DO: error handling in case of null object reference

            var fileName = content.FileName.Trim('"');

            var blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());

            await _gamesService.SetGame(title, genre, platform, releaseYear, blockBlob.Uri);

            return RedirectToAction("Index", "Catalog");
        }
    }
}