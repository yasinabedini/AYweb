using AIPFramework.Queries;
using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Domain.Models.Blog.Repositories;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Blog.Queries.GetBlogs
{
    public class GetBlogsQueryHandler : IQueryHandler<GetBlogsQuery, PagedData<BlogResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetBlogsQueryHandler(IBlogRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PagedData<BlogResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogList = _repository.GetListWithRelations();
            var blogs = _mapper.Map<List<Domain.Models.Blog.Entities.Blog>,List<BlogResult>>(blogList.Skip(request.SkipCount).Take(request.PageSize).ToList());

            if (!string.IsNullOrEmpty(request.search))
            {
                blogs = blogs.Where(t => t.Tags.Contains(request.search) || t.Title.Contains(request.search) || t.Text.Contains(request.search) || t.Introduction.Contains(request.search) || t.Summary.Contains(request.search)||(t.Author.FirstName+" "+t.Author.LastName).Contains(request.search)).ToList();
            }
            
            return Task.FromResult(new PagedData<BlogResult>() { QueryResult = blogs.Skip(request.SkipCount).Take(request.PageSize).ToList(), PageSize = request.PageSize, PageNumber = request.PageNumber, TotalCount = blogList.Count });
        }
    }
}
