namespace AYweb.Dal.Entities.Services;

public class Service
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public int? ParentId { get; set; }
    public Service? Parent { get; set; }
}