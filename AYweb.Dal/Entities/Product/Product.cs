using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AYweb.Dal.Entities.Order;

namespace AYweb.Dal.Entities.Product;

public class Product
{

    [Key]
    public int Id { get; set; }

    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Display(Name = "توضیح کوتاه")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public string? ShortDescription { get; set; }

    [Display(Name = "توضیحات محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public string? MainDescription { get; set; }

    [Display(Name = "توضیحات سئو ")]
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

    [Display(Name = "قیمت با تخفیف")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int? DiscountedPrice { get; set; }

    [Display(Name = "موجودی فعلی محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int Inventory { get; set; }

    [Display(Name = "محصول ویژه")]
    public bool IsSpecial { get; set; }


    public DateTime CreateDate { get; set; }

    public List<Feature>? Features { get; set; }
    public List<OrderLine>? OrderLines { get; set; }
    public List<Comment>? Comments { get; set; }

}