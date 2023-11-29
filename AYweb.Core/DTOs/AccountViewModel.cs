using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace AYweb.Core.DTOs;

public class LoginViewModel
{
    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(13, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
    [Phone(ErrorMessage = "لطفا شماره موبایل  خود را به درستی وارد کنید!")]
    public string PhoneNumber { get; set; }


    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Password { get; set; }

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RemmemberMe { get; set; }

    public string ReturnUrl { get; set; }
}

public class SignUpViewModel
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string LastName { get; set; }


    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(13, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
    [Phone(ErrorMessage = "لطفا شماره موبایل  خود را به درستی وارد کنید!")]
    public string PhoneNumber { get; set; }


    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Password { get; set; }
}