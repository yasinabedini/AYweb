using System.ComponentModel;

namespace AYweb.Dal.Entities.Project;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string ShamsiDateString { get; set; }
    public string CustomerName { get; set; }
    public string RelatedService { get; set; }
    public string Link { get; set; }
    public string MainImageName { get; set; }
    public string SecondImageName { get; set; }    
}