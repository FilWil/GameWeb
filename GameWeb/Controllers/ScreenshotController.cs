using System.Net.Http.Headers;
using System.Threading.Tasks;
using GameWeb.Interfaces;
using GameWeb.Models.Gallery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GameWeb.Controllers
{
    public class ScreenshotController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IScreenshot _screenshotService;

        public ScreenshotController(IConfiguration config, IScreenshot screenshotService)
        {
            _config = config;
            _screenshotService = screenshotService;
            AzureConnectionString = _config["AzureStorageConnectionString"];
        }

        private string AzureConnectionString { get; }

        public IActionResult Upload(int id)
        {
            var model = new UploadScreenshotModel
            {
                GameId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewScreenshot(IFormFile file, string tags, string title, int gameId)
        {
            var container = _screenshotService.GetBlobContainer(AzureConnectionString, "screenshots");

            var content =
                ContentDispositionHeaderValue.Parse(file
                    .ContentDisposition); //TO DO: error handling in case of null object reference

            var fileName = content.FileName.Trim('"');

            var blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());

            await _screenshotService.SetScreenshot(title, gameId, tags, blockBlob.Uri);

            return RedirectToAction("Index", "ScreenshotGallery", new {id = gameId});
        }
    }
}