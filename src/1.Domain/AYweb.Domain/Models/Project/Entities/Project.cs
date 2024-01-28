using AIPFramework.Entities;
using AYweb.Domain.Common.ValueObjects;


namespace AYweb.Domain.Models.Project.Entities;

public class Project : AggregateRoot
{
    #region Properties
    public Title Title { get; private set; }

    public Description ShortDescription { get; private set; }

    public Description Description { get; private set; }

    public string FirstImage { get; set; }
    public string SecondImage { get; set; }

    public string ShamsiDateString { get; private set; }

    public string CustomerName { get; private set; }

    public string RelatedService { get; private set; }

    public string Link { get; private set; }
       
    #endregion

    #region Constructor And Factories
    private Project() { }
    public Project(string title, string shortDescription, string description, string shamsiDateString, string customerName, string relatedService, string link,string firstImage, string secondImage)
    {
        Title = title;
        ShortDescription = shortDescription;
        Description = description;
        ShamsiDateString = shamsiDateString;
        CustomerName = customerName;
        RelatedService = relatedService;
        Link = link;
        CreateAt = DateTime.Now;
        FirstImage = firstImage;
        SecondImage = secondImage;        

    }
    public static Project Create(string title, string shortDescription, string description, string shamsiDateString, string customerName, string relatedService, string link,string firstImage,string secondImage)
    {
        return new Project(title, shortDescription, description, shamsiDateString, customerName, relatedService, link,firstImage,secondImage);
    }
    #endregion

    #region Common
    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChangeTitle(string title)
    {
        Title = title;
        Modified();
    }

    public void ChangeShortDescription(string shortDescription)
    {
        ShortDescription = shortDescription;
        Modified();
    }

    public void ChangeDescription(string description)
    {
        Description = description;
        Modified();
    }

    public void ChangeShamsiDateString(string shamsiDateString)
    {
        ShamsiDateString = shamsiDateString;
        Modified();
    }

    public void ChangeCustomerName(string customerName)
    {
        CustomerName = customerName;
        Modified();
    }

    public void ChangeRelatedService(string relatedService)
    {
        RelatedService = relatedService;
        Modified();
    }

    public void ChangeLink(string link)
    {
        Link = link;
        Modified();
    }
  
    public void Delete()
    {
        IsDelete = true;
        Modified();
    }
    #endregion

}