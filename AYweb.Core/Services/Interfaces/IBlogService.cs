using AYweb.Dal.Entities.News;
using Microsoft.AspNetCore.Http;

namespace AYweb.Core.Services.Interfaces;

public interface IBlogService
{
	#region Blog
    bool CreateBlog(News news, IFormFile newsPicture);
    List<News> GetAllNews();
	#endregion

	#region Blog Groups

    List<NewsGroup> GetAllNewsGroup();
    bool AddGroupToNews(int newsId, List<int> groups);

    #endregion

    #region Blog Galleris

    bool AddPictureToNewsGallery(int newsId, List<IFormFile> newsPictures);

    #endregion

    #region Blog Tags


    #endregion
}