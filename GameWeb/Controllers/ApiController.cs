using Microsoft.AspNetCore.Mvc;

namespace GameWeb.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult ShowApis()
        {
            return View();
        }
    }
}