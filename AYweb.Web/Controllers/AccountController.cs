using System.Drawing.Imaging;
using System.Security.Claims;
using AYweb.Core.DTOs;
using AYweb.Core.Senders;
using AYweb.Core.Services;
using AYweb.Core.Services.Interfaces;
using AYweb.Dal.Entities.User;
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
            if (_service.IsUserExisting(user.PhoneNumber)&&!_service.GetUserByPhoneNumber(user.PhoneNumber).PhoneNumberConfrimation)
            {
                return RedirectToAction("SendValidationSms", new { phoneNumber = user.PhoneNumber });
            }
            if (_service.IsUserExisting(user.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "کاربری با این شماره موبایل ثبت نام کرده است!");
                return View();
            }
            else
            {
                _service.UserRegister(user);
                return RedirectToAction("SendValidationSms",new { phoneNumber=user.PhoneNumber });
            }
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
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
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(user.ReturnUrl);
                    }
                }
                else
                {
                    ViewBag.NotVerficationPhoneNotification = true;                                        
                }
            }
            else
            {
                ViewBag.NotFoundUser = true;                
            }
            return View(user);
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

        [Route("SendValidationSms")]
        public IActionResult SendValidationSms(string phoneNumber)
        {
            User user = _service.GetUserByPhoneNumber(phoneNumber);
            string verificationCode = user.VerificationCode;

            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(verificationCode) || user == null || user.PhoneNumberConfrimation == true)
            {
                return NotFound();
            }
            Sms.SnedRegisterSms(phoneNumber, verificationCode);

            return RedirectToAction("VerificationPhoneNumber", new UserPhoneNumberViewModel() { PhoneNumber = phoneNumber });
        }


        [HttpGet("VerificationPhoneNumber")]
        [Route("VerificationPhoneNumber")]
        public IActionResult VerificationPhoneNumber([Bind] UserPhoneNumberViewModel verification)
        {

            return View(new VerificationUserViewModel { PhoneNumber = verification.PhoneNumber });
        }

        [HttpPost]
        [Route("VerificationPhoneNumber")]
        public IActionResult VerificationPhoneNumber(VerificationUserViewModel verification)
        {
            if (!ModelState.IsValid)
            {
                return View(new VerificationUserViewModel() { PhoneNumber = verification.PhoneNumber });
            }

            string verificationCode = _service.GetVerificationCode(verification.PhoneNumber);

            if (verification.Code != verificationCode)
            {
                ViewData["ErrorCode"] = true;
                return View(new VerificationUserViewModel() { PhoneNumber = verification.PhoneNumber });
            }

            _service.ConfirmPhoneNumber(verification.PhoneNumber);

            User user = _service.GetUserByPhoneNumber(verification.PhoneNumber);
            var claims = new List<Claim>()
                    {
                       new Claim(ClaimTypes.NameIdentifier,user.Username.ToString()),
                       new Claim(ClaimTypes.Name, user.FirstName+" "+user.LastName)
                    };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = false
            };
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
            Sms.WellCome(user.PhoneNumber, $"{user.FirstName} {user.LastName}");
            _orderService.SynchronizationCart(user.UserId);

            return RedirectToAction("Index", "Home");
        }
    }
}
