using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;

namespace AYweb.Domain.Models.Blog.Repositories
{
    public interface IBlogRepository: IRepository<Blog.Entities.Blog>
    {
        void AddGroupToBlog(long blogId, long groupId);
        void AddTagToBlog(long blogId, string tag);
        void ChangeImage(long blogId, string imageName);
        void ChangeIntroduction(long blogId, string introduction);
        void ChangeSummery(long blogId, string summery);
        void ChangeText(long blogId, string text);
        void ChangeTitle(long blogId, string title);
        Entities.Blog GetByIdWithRelations(long id);
    }
}
