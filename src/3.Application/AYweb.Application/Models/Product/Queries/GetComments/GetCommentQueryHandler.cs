using AIPFramework.Queries;
using AYweb.Application.Models.Product.Queries.Common;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Product.Repositories;
using System.Runtime.CompilerServices;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Product.Queries.GetComments
{
    public class GetCommentQueryHandler : IQueryHandler<GetCommentQuery, PagedData<CommentResult>>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetCommentQueryHandler(ICommentRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<PagedData<CommentResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var commentList = _repository.GetList().Skip(request.SkipCount).Take(request.PageSize).ToList();
            var comments = _mapper.Map<List<Comment>, List<CommentResult>>(commentList);

            return Task.FromResult(new PagedData<CommentResult>() { QueryResult = comments, PageNumber = request.PageNumber, PageSize = request.PageSize, TotalCount = comments.Count });
        }
    }
}
