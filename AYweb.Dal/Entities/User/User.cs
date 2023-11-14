using CarSpareParts.Dal.Entities.Discount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Dal.Entities.User;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Name { get; set; }

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Username { get; set; }


    [Display(Name = "شماره موبایل")]
    [MaxLength(13, ErrorMessage = "شماره موبایل خود را به درستی وارد کنید")]
    [Phone(ErrorMessage = "شماره موبایل خود را به درستی وارد کنید!")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "ایمیل")]
    [MaxLength(80, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
    [EmailAddress(ErrorMessage = "لطفا ایمیل خو را به درستی وارد کنید")]
    public string? Email { get; set; }

    [Display(Name = "تایید موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public bool PhoneNumberConfrimation { get; set; }

    [Display(Name = "تایید ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public bool EmailConfrimation { get; set; }


    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Password { get; set; }

    [Display(Name = "کد فعالسازی")]
    [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
    public string ActivationCode { get; set; }

    [Display(Name = "کد اعتبار سنجی")]
    [MaxLength(6, ErrorMessage = "{0} نمی تواند بیشتر از {1} باشد")]
    public string? VerificationCode { get; set; }

    [Display(Name = "وضعیت")]
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    [Display(Name = "تاریخ ثبت نام")]
    public DateTime RegisterDate { get; set; }

    [Display(Name = "آدرس")]
    public string? Address { get; set; }

    [DefaultValue(false)]
    public bool IsDelete { get; set; }

    [Display(Name = "نوع مشتری")]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public CustomerType Type { get; set; }
    public ICollection<Transaction.Transaction> Transactions { get; set; }
    public ICollection<Order.Order> Orders { get; set; }
    public ICollection<UserDiscounts> UserDiscounts { get; set; }
    public ICollection<Comment.Comment> Comments { get; set; }
}
