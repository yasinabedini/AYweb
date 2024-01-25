using System.Security.Claims;
using AYweb.Application.Models.User.Commands.ConfirmPhoneNumber;
using AYweb.Application.Models.User.Commands.CreateUser;
using AYweb.Application.Models.User.Commands.IsUserExisting;
using AYweb.Application.Models.User.Commands.LoginChack;
using AYweb.Application.Models.User.Queries.GetUserByPhoneNumber;
using AYweb.Application.Models.User.Queries.GetVerificationCode;
using AYweb.Core.Senders;
using AYweb.Domain.Models.User.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AYweb.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(CreateUserCommand user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_sender.Send(new IsUserExistingCommand { PhoneNumber = user.PhoneNumber }).Result && !_sender.Send(new GetUserByPhoneNumberQuery { PhoneNumber = user.PhoneNumber }).Result.PhoneNumberConfrimation)
            {
                return RedirectToAction("SendValidationSms", new { phoneNumber = user.PhoneNumber });
            }
            if (_sender.Send(new IsUserExistingCommand { PhoneNumber = user.PhoneNumber }).Result)
            {
                ModelState.AddModelError("PhoneNumber", "کاربری با این شماره موبایل ثبت نام کرده است!");
                return View();
            }
            else
            {
                _sender.Send(user);
                return RedirectToAction("SendValidationSms", new { phoneNumber = user.PhoneNumber });
            }
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginCommand { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginCommand user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userFound = _sender.Send(user).Result;
            if (userFound is not null)
            {
                if (userFound.PhoneNumberConfrimation)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,userFound.PhoneNumber),
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
                    //_orderService.SynchronizationCart(userFound.UserId);


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

        //[HttpPost]
        //public IActionResult AddEmailToNewsletters(string email)
        //{
        //    _service.AddEmailToNewsLatters(email);
        //    ViewBag.Subscribe = true;
        //    return RedirectToAction("Index", "Home");
        //}

        [Route("SendValidationSms")]
        public IActionResult SendValidationSms(string phoneNumber)
        {
            var user = _sender.Send(new GetUserByPhoneNumberQuery { PhoneNumber = phoneNumber }).Result;
            string verificationCode = user.VerificationCode;

            if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(verificationCode) || user == null || user.PhoneNumberConfrimation == true)
            {
                return NotFound();
            }

            Sms.SnedRegisterSms(phoneNumber, verificationCode);

            return RedirectToAction("VerificationPhoneNumber", new { phoneNumber = phoneNumber });
        }


        [HttpGet("VerificationPhoneNumber")]
        [Route("VerificationPhoneNumber")]
        public IActionResult VerificationPhoneNumber(string phoneNumber)
        {

            return View(new ConfirmPhoneNumberCommand { PhoneNumber = phoneNumber });
        }

        [HttpPost]
        [Route("VerificationPhoneNumber")]
        public IActionResult VerificationPhoneNumber(ConfirmPhoneNumberCommand verification)
        {
            if (!ModelState.IsValid)
            {
                return View(new ConfirmPhoneNumberCommand() { PhoneNumber = verification.PhoneNumber });
            }

            verification.VereficationCode = _sender.Send(new GetVerificationCodeQuery { PhoneNumber = verification.PhoneNumber }).Result;

            bool isSuccess = _sender.Send(verification).Result;
            if (!isSuccess)
            {
                ViewData["ErrorCode"] = true;
                return View(new ConfirmPhoneNumberCommand { PhoneNumber = verification.PhoneNumber });
            }



            var user = _sender.Send(new GetUserByPhoneNumberQuery { PhoneNumber = verification.PhoneNumber }).Result;
            var claims = new List<Claim>()
                    {
                       new Claim(ClaimTypes.NameIdentifier,user.PhoneNumber),
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
            //_orderService.SynchronizationCart(user.UserId);

            return RedirectToAction("Index", "Home");
        }
    }
}
