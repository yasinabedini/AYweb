using System.ComponentModel;

namespace AYweb.Dal.Entities.Project;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string CustomerName { get; set; }
    public string RelatedService { get; set; }
    public string Link { get; set; }
    public string ImageName { get; set; }

    public List<ProjectGallery> Galleries { get; set; }
}