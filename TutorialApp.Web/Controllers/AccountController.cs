using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using TutorialApp.Core.Convertors;
using TutorialApp.Core.DTOs;
using TutorialApp.Core.Security;
using TutorialApp.Core.Services.Interfaces;
using TutorialApp.Core.Utils;
using TutorialApp.Datalayer.Entities.User;

namespace TutorialApp.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        #region Register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid)
            {
                return View(register);
            }
            if(_userService.IsUsernameExist(register.Username))
            {
                ModelState.AddModelError("Username", "The username is not valid.");
                return View(register);
            }
            if(_userService.IsEmailExist(InputConvertors.EmailValidator(register.Email)))
            {
                ModelState.AddModelError("Email", "The email is not valid.");
                return View(register);
            }

            User user = new User()
            {
                Username = register.Username,
                Email = InputConvertors.EmailValidator(register.Email),
                Password = HashString.hashString(register.Password),
                IsActive = false,
                ActiveCode = CodeGenerator.stringCodeGenerator(),
                RegisterDate = DateTime.Now,
                UserAvatar = "default.jpeg",

            };

            _userService.AddUser(user);
            //TODO: send activation email
            return View("SuccessRegister",user);
        }
        #endregion



        #region Login
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
             var user = _userService.LoginUser(login);
            if(user != null)
            {
                if(user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.Username)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe,
                    };

                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "Your account is not active.");
                }
            }
            ModelState.AddModelError("Email", "The User not found.");
            return View(login);
        }
        #endregion


        #region Active Account
        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _userService.ActiveAccount(id);
            return View();
        }
        #endregion

        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }
        #endregion

    }


}
