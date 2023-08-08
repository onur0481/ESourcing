using Esourcing.UI.ViewModel;
using ESourcing.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Esourcing.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (!ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());
                        return LocalRedirect(returnUrl);
                    }

                    else ModelState.AddModelError("", "Email address is not valid or password");
                }
                else ModelState.AddModelError("", "Email address is not valid or password");

            }
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserViewModel appUserViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new();

                appUser.FirsName = appUserViewModel.FirstName;
                appUser.Email = appUserViewModel.Email;
                appUser.LastName = appUserViewModel.LastName;
                appUser.PhoneNumber = appUserViewModel.PhoneNumber;
                appUser.UserName = appUserViewModel.UserName;
                if (appUserViewModel.UserSelectTypeID == 1)
                {
                    appUser.IsBuyer = true;
                    appUser.IsSaller = false;
                }
                else
                {
                    appUser.IsSaller = true;
                    appUser.IsBuyer = false;
                }

                var result = await _userManager.CreateAsync(appUser, appUserViewModel.Password);

                if (result.Succeeded) return RedirectToAction("Login");
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(appUserViewModel);
        }


        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
