using AIPFramework.Entities;

namespace AYweb.Domain.Models.Blog.Entities;

public class Blog : AggregateRoot
{
    #region Properties
    public string Title { get; private set; }

    public string Summary { get; private set; }

    public string Introduction { get; private set; }    

    public string Text { get; private set; }

    public long AuthorId { get; init; }

    public string? Tags { get; private set; }
    
    public string ImageName { get; private set; }

    public List<Gallery.Entities.Gallery> Galleries { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; private set; }

    public User.Entities.User Author { get; set; }

    public List<Blog_Groups> Groups { get; set; } 
    #endregion

    #region Constructor And Factories
    private Blog() { }
    public Blog(string title, string summery, string introduction, string text, int authorId, string? tags, string imageName)
    {
        Title = title;
        Summary = summery;
        Introduction = introduction;
        Text = text;
        AuthorId = authorId;
        Tags = tags;
        ImageName = imageName;
        CreateAt = DateTime.Now;
    }

    public static Blog Create(string title, string summery, string introduction, string text, int authorId, string? tags, string imageName)
    {
        return new Blog(title, summery, introduction, text, authorId, tags, imageName);
    }
    #endregion

    #region Command

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChangeTitle(string title)
    {
        Title = title;
        Modified();
    }

    public void ChangeSummary(string summary)
    {
        Summary = summary;
        Modified();
    }

    public void ChangeIntroduction(string introduction)
    {
        Introduction =introduction;
        Modified();
    }

    public void ChangeText(string text)
    {
        Text = text;
        Modified();
    }

    public void ChangeImageName(string imageName)
    {
        ImageName = imageName;
        Modified();
    }

    public void ChangeTags(string tags)
    {
        Tags = tags;
        Modified();
    }

    public void AddTags(string tags)
    {
        Tags.Concat("," + tags);
        Modified();
    }

    public void DeleteBlog()
    {
        IsDeleted = true;
        Modified();
    }

    public void UpdateBlog(string? title, string? summery, string? introduction, string? text, string? imageName, string? tags)
    {
        if (!string.IsNullOrEmpty(title)) ChangeTitle(title);
        if (!string.IsNullOrEmpty(summery)) ChangeSummary(summery);
        if (!string.IsNullOrEmpty(introduction)) ChangeIntroduction(introduction);
        if (!string.IsNullOrEmpty(text)) ChangeText(text);
        if (!string.IsNullOrEmpty(imageName)) ChangeImageName(imageName);
        if (!string.IsNullOrEmpty(tags)) ChangeTags(tags);
    }

    #endregion
}
