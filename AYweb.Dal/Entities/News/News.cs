using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

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
    public string Introduction { get; set; }
    public string Text { get; set; }
    public bool IsDeleted { get; set; }
    public string Summary { get; set; }
    public int UserId { get; set; }
    public string? Tags { get; set; }
    public string? PictureName { get; set; }
    public DateTime CreateDate { get; set; }


    public List<Gallery.Gallery>? NewsGalleries { get; set; }
    public User.User? User { get; set; }
    public List<NewsGroups>? GroupsList { get; set; }
    public List<NewsComment>? NewsComments { get; set; }
}