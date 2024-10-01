using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWithValue.Domain.ViewModels.Login;

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
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                    return View(model);
                }

                var roles = await _userManager.GetRolesAsync(user);

                // بررسی نقش کاربر و هدایت به صفحه مناسب
                if (roles.Contains("Agent"))
                {
                    return RedirectToAction("AgentDashboard", "Support");
                }
                else if (roles.Contains("User"))
                {
                    return RedirectToAction("UserChat", "Support");
                }
            }
            else
            {
                // لاگ خطا
                //var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description)); // اصلاح شده
                //ModelState.AddModelError(string.Empty, $"Invalid login attempt: {errorMessage}");
            }
        }
        return View(model);
    }



    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Auth");
    }
}
