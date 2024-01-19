using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;

namespace AYweb.Domain.Models.Blog.Repositories
{
    public interface IBlogCommentRepository:IRepository<BlogComment>
    {
        List<BlogComment> GetBlogComments(long blogId);
    }
}
