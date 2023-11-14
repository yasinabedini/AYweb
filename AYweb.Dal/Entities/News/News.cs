using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.News;

public class News
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "عنوان خبر")]
    [Required(ErrorMessage = "لطفا {0} را وارو کنید!")]
    public string Title { get; set; }

    [Display(Name = "متن خبر")]
    [Required(ErrorMessage = "لطفا {0} را وارو کنید!")]
    public string Text { get; set; }
    public bool IsDeleted { get; set; }
}