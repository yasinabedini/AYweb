using AYweb.Core.Generators;
using AYweb.Core.Services.Interfaces;
using AYweb.Core.Tools;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.News;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services;

public class BlogService : IBlogService
{
    private readonly AYWebDbContext _context;

    public BlogService(AYWebDbContext context)
    {
        _context = context;
    }


    public bool CreateBlog(News news, IFormFile newsPicture)
    {
        string pictureName;

        pictureName = Generator.CreateUniqueText() + Path.GetExtension(newsPicture.FileName);
        FileTools file = new FileTools();
        file.SaveImage(newsPicture, pictureName, "blog-image", true);

        _context.News.Add(new News()
        {
            Title = news.Title,
            Text = news.Text,
            Summary = news.Summary,
            CreateDate = DateTime.Now,
            UserId = news.UserId,
            PictureName = pictureName,
            Tags = news.Tags,
        });

        return _context.SaveChanges() == 1;
    }

    public List<News> GetAllNews()
    {
        return null;
    }

    public List<NewsGroup> GetAllNewsGroup()
    {
        return _context.NewsGroups.ToList();
    }

    public bool AddGroupToNews(int newsId, List<int> groups)
    {
        foreach (var groupId in groups)
        {
            _context.News_Groups.Add(new NewsGroups()
            {
                NewsId = newsId,
                NewsGroupId = groupId
            });
        }

        return _context.SaveChanges() == 1;
    }

    public bool AddPictureToNewsGallery(int newsId, List<IFormFile> newsPictures)
    {
        foreach (var picture in newsPictures)
        {
            string pictureName = Generators.Generator.CreateUniqueText() + Path.GetExtension(picture.FileName);
            FileTools file = new FileTools();
            file.SaveImage(picture, pictureName, "blog-gallery", false);
            _context.NewsGalleries.Add(new NewsGallery()
            {
                NewsId = newsId,
                ImageName = pictureName
            });
        }

        return _context.SaveChanges() == 1;
    }
}