using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.User;

public class Newsletters
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "آدرس ایمیل")]
    [EmailAddress(ErrorMessage = "آدرس ایمیل را به درستی وارد کنید!")]
    [Required(ErrorMessage = "ایمیل را وارد کنید!")]
    public string Email { get; set; }
}