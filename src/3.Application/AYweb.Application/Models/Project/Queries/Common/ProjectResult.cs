namespace AYweb.Application.Models.Project.Queries.Common;

public class ProjectResult
{
    public long Id { get; set; }
    public required string Title { get; set; }

    public required string ShortDescription { get; set; }

    public required string Description { get; set; }

    public required string FirstImage { get; set; }

    public required string SecondImage { get; set; }

    public required string ShamsiDateString { get; set; }

    public required string CustomerName { get; set; }

    public required string RelatedService { get; set; }

    public required string Link { get; set; }
}
