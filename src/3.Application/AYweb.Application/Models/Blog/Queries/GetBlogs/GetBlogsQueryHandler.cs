using AIPFramework.Queries;
using AYweb.Domain.Models.Blog.Repositories;
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
            var blogList = _repository.GetList();
            var blogs = _mapper.Map<List<Domain.Models.Blog.Entities.Blog>,List<BlogListResult>>(blogList.Skip(request.SkipCount).Take(request.PageSize).ToList());
            
            
            return Task.FromResult(new PagedData<BlogListResult>() { QueryResult = blogs.Skip(request.SkipCount).Take(request.PageSize).ToList(), PageSize = request.PageSize, PageNumber = request.PageNumber, TotalCount = blogList.Count });
        }
    }
}
