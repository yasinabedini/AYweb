using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;

namespace AYweb.Domain.Models.Blog.Repositories
{
    public interface IUserRepository: IRepository<Blog.Entities.Blog>
    {
    }
}
