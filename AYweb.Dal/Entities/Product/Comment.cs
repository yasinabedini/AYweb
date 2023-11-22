namespace AYweb.Dal.Entities.Product;

public class Comment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int ProductId { get; set; }
    public string User_name { get; set; }
    public string User_phoneNumber { get; set; }
    public bool IsConfirmed { get; set; }
    public Product Product { get; set; }
    public DateTime CreateDate { get; set; }
}