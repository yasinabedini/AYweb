using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Blog.Repositories
{
    public interface IBlogGroupRepository:IRepository<BlogGroup>
    {
        List<BlogGroup> GetBlogGroupsByBlogId(long blogId);
    }
}
