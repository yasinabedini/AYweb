using System.Security.AccessControl;

namespace AYweb.Dal.Entities.News;

public class NewsGroups
{
    public int NG_Id { get; set; }
    public int NewGroupId { get; set; }
    public int NewsId { get; set; }

    public NewsGroup NewsGroup { get; set; }
    public News News { get; set; }
}