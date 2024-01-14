using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Blog.Repositories;

public class BlogRepository : IBlogRepository
{
    public void Add(Domain.Models.Blog.Entities.Blog entity)
    {
        throw new NotImplementedException();
    }

    public Domain.Models.Blog.Entities.Blog GetById(long id)
    {
        throw new NotImplementedException();
    }

    public List<Domain.Models.Blog.Entities.Blog> GetList()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.Models.Blog.Entities.Blog entity)
    {
        throw new NotImplementedException();
    }
}
