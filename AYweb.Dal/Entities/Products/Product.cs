using AYweb.Dal.Entities.Project;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace AYweb.Dal.Entities.Products;

public class Product
{

    [Key]
    public int Id { get; set; }

    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Display(Name = "توضیحات محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public string? Description { get; set; }

    [Display(Name = "توضیحات ")]
    public string? HideDescription { get; set; }

    [Display(Name = "وضعیت")]
    [DefaultValue(true)]
    public bool IsActive { get; set; }

    [Display(Name = "حذف شده ؟ ")]
    [DefaultValue(false)]
    public bool IsDelete { get; set; }

    [Display(Name = "تصویر کالا")]
    public string? PictureName { get; set; }

    public bool InventoryStatus { get; set; }

    [Display(Name = "قیمت")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int Price { get; set; }

    [Display(Name = "موجودی فعلی محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int Inventory { get; set; }

    public DateTime CreateDate { get; set; }

}