using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestWithValue.Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
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
        public IActionResult SupportChat()
        {
            // بررسی نقش پشتیبان
            if (User.IsInRole("Agent"))
            {
                return View(); // بازگشت به ویو SupportChat
            }
            return RedirectToAction("Login", "Auth"); // در صورت عدم نقش صحیح، به صفحه ورود هدایت شود
        }

        // متدهای مربوط به دریافت و ارسال پیام‌ها در اینجا اضافه می‌شود
    }
}
