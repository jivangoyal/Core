using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public IActionResult Index()
        {
            Logger.Info("Index page says hello");
            return View();
        }
    }
}