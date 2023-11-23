using System.ComponentModel.DataAnnotations.Schema;

namespace AYweb.Dal.Entities.News;

public class NewsGallery
{
    public int Id { get; set; }
    public string ImageName { get; set; }

    public int NewsId { get; set; }
    [ForeignKey("NewsId")]
    public News News { get; set; }
}