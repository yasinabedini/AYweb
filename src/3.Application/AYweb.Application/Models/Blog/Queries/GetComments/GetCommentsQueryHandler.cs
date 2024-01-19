using AIPFramework.Queries;
using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Blog.Repositories;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Blog.Queries.GetComments
{
    public class GetCommentsQueryHandler : IQueryHandler<GetCommentsQuery, PagedData<CommentResult>>
    {
        private readonly IBlogCommentRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetCommentsQueryHandler(IBlogCommentRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PagedData<CommentResult>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = _mapper.Map<List<BlogComment>,List<CommentResult>>(_repository.GetList());
            comments = comments.Skip(request.SkipCount).Take(request.PageSize).ToList();

            return Task.FromResult(new PagedData<CommentResult>() { QueryResult = comments, PageNumber = request.PageNumber, PageSize = request.PageSize, TotalCount = comments.Count });

        }
    }
}
