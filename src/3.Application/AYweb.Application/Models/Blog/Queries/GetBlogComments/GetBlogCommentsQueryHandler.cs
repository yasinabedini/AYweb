using AIPFramework.Queries;
using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Blog.Queries.GetBlogComments
{
    public class GetBlogCommentsQueryHandler : IQueryHandler<GetBlogCommentsQuery, List<CommentResult>>
    {
        private readonly IBlogCommentRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetBlogCommentsQueryHandler(IBlogCommentRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<CommentResult>> Handle(GetBlogCommentsQuery request, CancellationToken cancellationToken)
        {
            var blogComments = _mapper.Map<List<BlogComment>, List<CommentResult>>(_repository.GetBlogComments(request.BlogId));

            return Task.FromResult(blogComments);
        }
    }
}
