using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWithValue.Application.Services.Services_Interface;

namespace TestWithValue.Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ITicketService _ticketService;
        public ChatController(ITicketService ticketService)
        {
            _ticketService = ticketService;   
        }
        public IActionResult Index()
        {
            return View(); // بازگشت به ویو index
        }

        [HttpGet]
        public IActionResult CheckUserRole()
        {
            if (User.IsInRole("User"))
            {
                return Json(new { isLoggedIn = true, role = "User" });
            }
            else if (User.IsInRole("Agent"))
            {
                return Json(new { isLoggedIn = true, role = "Agent" });
            }

            return Json(new { isLoggedIn = false });
        }
        public async Task <IActionResult> SupportChat()
        {
            // بررسی نقش پشتیبان
            if (User.IsInRole("Agent"))
            {
                var tickets = await _ticketService.GetAllTicketsAsync();
                return View(tickets); // ارسال لیست تیکت‌ها به ویو
                 // بازگشت به ویو SupportChat
            }
            return RedirectToAction("Login", "Auth"); // در صورت عدم نقش صحیح، به صفحه ورود هدایت شود
        }

        // متدهای مربوط به دریافت و ارسال پیام‌ها در اینجا اضافه می‌شود
    }
}
