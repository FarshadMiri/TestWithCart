using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWithValue.Domain.ViewModels.Login;
using TestWithValue.Domain.ViewModels.Register;

public class AuthController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var User = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(User, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var identityError in result.Errors)
            {
                ModelState.AddModelError("", identityError.Description);

            }


        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
        ViewData["returnUrl"] = returnUrl;
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Index", "Home");
        }

        ViewData["returnUrl"] = returnUrl;

        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var roles = await _userManager.GetRolesAsync(user);
                string role = roles.Count > 0 ? roles[0] : "Guest";

                TempData["isLoggedIn"] = true;
                TempData["role"] = role;

                if (role == "Agent") // اگر نقش Agent بود
                {
                    return RedirectToAction("SupportChat", "Chat"); // به صفحه supportchat هدایت شود
                }
                else if (role == "User") // اگر نقش کاربر عادی بود
                {
                    return RedirectToAction("Index", "Home"); // به صفحه index هدایت شود و چت در آن نمایش داده شود
                }
            }

            if (result.IsLockedOut)
            {
                ViewData["ErrorMessage"] = "به دلیل 5 بار ورود ناموفق اکانت شما به مدت 5 دقیقه قفل شده است.";
                return View(model);
            }

            ModelState.AddModelError("", "رمز عبور یا نام کاربری درست نمی‌باشد");
        }

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Auth");
    }

    [HttpGet]
    public IActionResult CheckUserStatus()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Json(new { isLoggedIn = false });
        }

        string role = "Guest";
        if (User.IsInRole("Agent"))
        {
            role = "Agent";
        }
        else if (User.IsInRole("User"))
        {
            role = "User";
        }

        return Json(new { isLoggedIn = true, role = role });
    }
}
