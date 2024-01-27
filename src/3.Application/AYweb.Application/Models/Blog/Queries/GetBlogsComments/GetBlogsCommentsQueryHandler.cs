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

namespace AYweb.Application.Models.Blog.Queries.GetBlogsComments
{
    public class GetBlogsCommentsQueryHandler : IQueryHandler<GetBlogsCommentsQuery, List<CommentResult>>
    {
        private readonly IBlogCommentRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetBlogsCommentsQueryHandler(IBlogCommentRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<CommentResult>> Handle(GetBlogsCommentsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<BlogComment>, List<CommentResult>>(_repository.GetList()));
        }
    }
}
