using System.Security.Claims;
using AYweb.Core.DTOs;
using AYweb.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;
        private readonly IOrderService _orderService;

        public AccountController(IUserService service, IOrderService orderService)
        {
            _service = service;
            _orderService = orderService;
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(SignUpViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_service.IsUserExisting(user.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "کاربری با این شماره موبایل ثبت نام کرده است!");
                return View();
            }
            else
            {
                _service.UserRegister(user);
                return RedirectToAction("Index","Home");
            }
            return View();
        }



        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel(){ReturnUrl = returnUrl});
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userFound = _service.LoginUser(user);
            if (userFound is not null)
            {                
                if (userFound.PhoneNumberConfrimation)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,userFound.Username),
                        new Claim(ClaimTypes.Name, userFound.FirstName+" "+userFound.LastName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = user.RemmemberMe,
                        AllowRefresh = user.RemmemberMe,

                    };
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
                    _orderService.SynchronizationCart(userFound.UserId);
                    

                    if (user.ReturnUrl == "/")
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        return LocalRedirect(user.ReturnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("PhoneNumber", "شماره موبایل خود دار تایید نکرده اید");
                    ViewBag.ConfirmPhone = true;
                    //TODO Confirm Phone
                }
            }
            else
            {
                ModelState.AddModelError("PhoneNumber","شماره موبایل یا رمز عبور نادرست است!");
                return View();
            }
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AddEmailToNewsletters(string email)
        {
            _service.AddEmailToNewsLatters(email);
            ViewBag.Subscribe = true;
            return RedirectToAction("Index", "Home");
        }
    }
}
