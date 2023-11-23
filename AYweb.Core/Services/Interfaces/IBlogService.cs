using AYweb.Core.DTOs;
using AYweb.Dal.Entities.News;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services.Interfaces;

public interface IBlogService
{
    #region Blog
    void CreateBlog(News news, IFormFile newsPicture);
    Tuple<List<ShowBlogViewModel>,int> GetAllNews(int pageId = 1, string search = "", int take = 8);
    News GetNewsById(int id);
    #endregion

    #region Blog Groups

    List<NewsGroup> GetAllNewsGroup();
    bool AddGroupToNews(int newsId, List<int> groups);

    #endregion

    #region Blog Galleris

    bool AddPictureToNewsGallery(int newsId, List<IFormFile> newsPictures);

    #endregion

    #region Blog Tags

    List<string> GetAllTags();
    int GetTagsNewsCount(string tags);

    #endregion
}