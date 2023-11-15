namespace AYweb.Dal.Entities.Project;

public class ProjectGallery
{
    public int Id { get; set; }
    public string ImageName { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}