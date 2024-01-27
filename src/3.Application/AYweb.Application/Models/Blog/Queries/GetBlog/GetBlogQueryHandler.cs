using AIPFramework.Queries;
using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Blog.Queries.GetBlog
{
    public class GetBlogQueryHandler : IQueryHandler<GetBlogQuery, BlogResult>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetBlogQueryHandler(IBlogRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BlogResult> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetByIdWithRelations(request.Id);
            

            return Task.FromResult(_mapper.Map<Domain.Models.Blog.Entities.Blog, BlogResult>(blog));
        }
    }
}
