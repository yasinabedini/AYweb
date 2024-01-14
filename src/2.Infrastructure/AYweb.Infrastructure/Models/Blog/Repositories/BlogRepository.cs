using AYweb.Domain.Models.Blog.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Blog.Repositories;

public class BlogRepository : BaseRepository<Domain.Models.Blog.Entities.Blog>, IBlogRepository
{
    public BlogRepository(AyWebDbContext context) : base(context)
    {
    }
}
