using System.Security.AccessControl;

namespace AYweb.Core.DTOs;

public class ShowBlogViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summery { get; set; }
    public string ImageName { get; set; }
    public string UserName { get; set; }
    public DateTime CreateDate { get; set; }

}

public class PopularBlogViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreateDate { get; set; }
    public string ImageName { get; set; }
}


public class BlogLastCommentViewModel
{
    public int Id { get; set; }
    public int NewsId { get; set; }
    public string User_Name { get; set; }
    public string NewsTitle { get; set; }
}