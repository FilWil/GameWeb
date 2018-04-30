using GameWeb.Models;
using GameWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GameWeb.Controllers
{
    public class ScreenshotController : Controller
    {
        private IConfiguration _config;
        private IScreenshot _screenshotService;
        private string AzureConnectionString { get; }

        public ScreenshotController(IConfiguration config, IScreenshot screenshotService)
        {
            _config = config;
            _screenshotService = screenshotService;
            AzureConnectionString = _config["AzureStorageConnectionString"];
        }

        public IActionResult Upload()
        {
            var model = new UploadScreenshotModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewScreenshot(IFormFile file, string tags, string title)
        {
            var container = _screenshotService.GetBlobContainer(AzureConnectionString, "screenshots");

            var content = ContentDispositionHeaderValue.Parse(file.ContentDisposition); //TO DO: error handling in case of null object reference
            var fileName = content.FileName.Trim('"');

            var blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());

            await _screenshotService.SetScreenshot(title, tags, blockBlob.Uri);

            return RedirectToAction("Index", "ScreenshotGallery");
            
        }
    }
}