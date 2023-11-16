using System.ComponentModel.DataAnnotations;

namespace AYweb.Core.DTOs;

public class ProductViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Display(Name = "قیمت")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int Price { get; set; }

    [Display(Name = "وضعیت موجودی")]
    public int StatusId { get; set; }

    [Display(Name = "موجودی فعلی محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int Inventory { get; set; }

}

public class FullProductViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Display(Name = "قیمت")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int Price { get; set; }

    [Display(Name = "وضعیت موجودی")]
    public int StatusId { get; set; }

    [Display(Name = "موجودی فعلی محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int Inventory { get; set; }

    public List<string> Groups { get; set; }
    public List<string> Cars { get; set; }
}

public class ShowProductForAdminViewModel
{
    public List<ProductViewModel> Products { get; set; }
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }

}

public class ShowProductViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Display(Name = "قیمت")]
    [Required(ErrorMessage = "{0} را وارد کنید!")]
    public int Price { get; set; }

    [Display(Name = "تصویر کالا")]
    public string? PictureName { get; set; }

    public DateTime CreateDate { get; set; }
}
