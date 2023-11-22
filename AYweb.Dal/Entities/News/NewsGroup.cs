using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace AYweb.Dal.Entities.News;

public class NewsGroup
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارو کنید!")]
    public string Title { get; set; }

    public List<NewsGroups>? NewsList { get; set; }
}