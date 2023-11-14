using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace AYweb.Dal.Entities.Company;

public class Company
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "عنوان سایت")]
    [Required(ErrorMessage = "لطفا {0} را وارو کنید!")]
    public string Name { get; set; }

    [Display(Name = "تعداد اعضای تیم")]
    [Required(ErrorMessage = "لطفا {0} را وارو کنید!")]
    public int TeamCount { get; set; }

    [Display(Name = "تعداد پروژه ها")]
    [Required(ErrorMessage = "لطفا {0} را وارو کنید!")]
    public int ProjectCount { get; set; }

}