using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace AYweb.Dal.Entities.News;

public class NewsGroups
{
    [Key]
    public int NG_Id { get; set; }
    public int NewsGroupId { get; set; }
    public int NewsId { get; set; }

    public NewsGroup NewsGroup { get; set; }
    public News News { get; set; }
}