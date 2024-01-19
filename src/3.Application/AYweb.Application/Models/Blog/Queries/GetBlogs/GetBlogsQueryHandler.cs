using AIPFramework.Queries;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Blog.Queries.GetBlogs
{
    public class GetBlogsQueryHandler : IQueryHandler<GetBlogsQuery, PagedData<BlogListResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetBlogsQueryHandler(IBlogRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PagedData<BlogListResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = _mapper.Map<List<Domain.Models.Blog.Entities.Blog>,List<BlogListResult>>(_repository.GetList());
            
            ;
            return Task.FromResult(new PagedData<BlogListResult>() { QueryResult = blogs.Skip(request.SkipCount).Take(request.PageSize).ToList(), PageSize = request.PageSize, PageNumber = request.PageNumber, TotalCount = blogs.Count });
        }
    }
}
