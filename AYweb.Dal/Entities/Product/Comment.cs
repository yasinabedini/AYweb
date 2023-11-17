namespace AYweb.Dal.Entities.Products;

public class Comment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public bool IsConfirmed { get; set; }
    public User.User User { get; set; }
    public Product Product { get; set; }
}