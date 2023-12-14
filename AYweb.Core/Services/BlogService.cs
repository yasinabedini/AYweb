using AYweb.Core.Convertors;
using AYweb.Core.DTOs;
using AYweb.Core.Generators;
using AYweb.Core.Services.Interfaces;
using AYweb.Core.Tools;
using AYweb.Dal.Context;
using AYweb.Dal.Entities.Gallery;
using AYweb.Dal.Entities.News;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AYweb.Core.Services;

public class BlogService : IBlogService
{
    private readonly AYWebDbContext _context;

    public BlogService(AYWebDbContext context)
    {
        _context = context;
    }


    public void CreateBlog(News news, IFormFile newsPicture)
    {
        string pictureName;

        pictureName = Generator.CreateUniqueText(12) + Path.GetExtension(newsPicture.FileName);
        FileTools file = new FileTools();
        file.SaveImage(newsPicture, pictureName, "blog-image", true);

        news.PictureName = pictureName;
        news.CreateDate = DateTime.Now;

        _context.News.Add(news);
        _context.SaveChanges();
    }

    public Tuple<List<ShowBlogViewModel>, int> GetAllNews(int pageId = 1, string search = "", int take = 8)
    {
        var newsList = _context.News.Include(t => t.GroupsList).ThenInclude(t => t.NewsGroup).Include(t => t.User).Include(t => t.NewsGalleries).AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            newsList = newsList.Where(t => t.Title.Contains(search) || t.Summary.Contains(search) || t.Text.Contains(search) || t.Tags.Contains(search) || (t.User.FirstName+" "+t.User.LastName).Contains(search) || t.GroupsList.Select(c => c.NewsGroup.Title).Any(g => g.Contains(search)));
        }

        int skip = (pageId - 1) * take;

        newsList = newsList.Skip(skip).Take(take);

        var finalList = newsList.Select(t => new ShowBlogViewModel()
        {
            Id = t.Id,
            Title = t.Title,
            Summery = t.Summary,
            ImageName = t.PictureName,
            CreateDate = t.CreateDate,
            UserName = t.User.FirstName + " " + t.User.LastName
        }).ToList();
        int pageCount = finalList.Count / take;
        if (pageCount <= 1)
        {
            pageCount = 1;
            goto endNewsList;
        }
        if ((pageCount % take) != 0)
        {
            pageCount++;
        }

    endNewsList:
        return Tuple.Create(finalList, pageCount);
    }

    public News GetNewsById(int id)
    {
        return _context.News.Include(t => t.User).Include(t => t.NewsGalleries).Include(t => t.GroupsList).Include(t => t.NewsComments).First(t => t.Id == id);
    }

    public List<PopularBlogViewModel> GetPopularNews()
    {
        return _context.News.OrderBy(t => t.NewsComments.Count).Select(t => new PopularBlogViewModel()
        {
            Id = t.Id,
            Title = t.Title,
            CreateDate = t.CreateDate,
            ImageName = t.PictureName
        }).ToList();
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
            string pictureName = Generators.Generator.CreateUniqueText(12) + Path.GetExtension(picture.FileName);
            FileTools file = new FileTools();
            file.SaveImage(picture, pictureName, "blog-gallery", false);
            var news = _context.News.Find(newsId);
            news.NewsGalleries.Add(new Gallery(){ImageName = pictureName});
            _context.Update(news);
        }

        return _context.SaveChanges() == 1;
    }

    public List<string> GetAllTags()
    {
        var tagsStr = _context.News.Select(t => t.Tags).ToList();

        List<string> tags = new List<string>();
        foreach (var tag in tagsStr)
        {
            tags.AddRange(StringConvertToStringArray.CommaSeparator(tag).ToList());
        }

        return tags;
    }

    public int GetTagsNewsCount(string tag)
    {
        return _context.News.Where(t => t.Tags.Contains(tag)).ToList().Count();
    }

    public List<BlogLastCommentViewModel> GetLastComment()
    {
        return _context.NewsComments.Include(t => t.News).OrderByDescending(t => t.CreateDate).Take(6).Select(t =>
            new BlogLastCommentViewModel()
            {
                Id = t.Id,
                User_Name = t.User_name,
                NewsTitle = t.News.Title,
                NewsId = t.NewsId
            }).ToList();
    }
}