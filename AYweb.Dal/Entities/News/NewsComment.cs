namespace AYweb.Dal.Entities.News;

public class NewsComment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int NewsId { get; set; }
    public string User_name { get; set; }
    public string User_phoneNumber { get; set; }
    public DateTime CreateDate { get; set; }
    

    public News News { get; set; }
}