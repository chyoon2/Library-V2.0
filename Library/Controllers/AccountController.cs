using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Library.Models;
using System.Threading.Tasks;
using Library.ViewModels;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<LibrarianUser> _userManager;
        private readonly SignInManager<LibrarianUser> _signInManager;

        public AccountController (UserManager<LibrarianUser> userManager, SignInManager<LibrarianUser> signInManager, LibraryContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
          Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
          if (result.Succeeded)
          {
              return RedirectToAction("Index");
          }
          else
          {
              return View();
          }
        }
        [HttpPost]
        public async Task<ActionResult> Register (RegisterViewModel model)
        {
          var user = new LibrarianUser { UserName = model.Email };
          IdentityResult result = await _userManager.CreateAsync(user, model.Password);
          if (result.Succeeded)
          {
              return RedirectToAction("Index");
          }
          else
          {
              return View();
          }
        }
        [HttpPost]
        public async Task<ActionResult> LogOff()
        {
          await _signInManager.SignOutAsync();
          return RedirectToAction("Index");
        }
    }
}