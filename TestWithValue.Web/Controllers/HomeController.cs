using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWithValue.Application.Services.Services.OperationResultService;
using TestWithValue.Application.Services.Services_Interface.ActionMessage_s_Interface;
using TestWithValue.Web.Models;

namespace TestWithValue.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActionMessageService _actionMessageService;
        public HomeController(ILogger<HomeController> logger, IActionMessageService actionMessageService)
        {
            _logger = logger;
            _actionMessageService = actionMessageService;
        }

        public IActionResult Index()
        {
            //_actionMessageService.AddMessage("Welcome to the homepage!", "success");


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
