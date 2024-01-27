using AIPFramework.Queries;
using AYweb.Application.Convertors;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Queries.GetTags
{
    public class GetTagsQueryHandler : IQueryHandler<GetTagsQuery, List<string>>
    {
        private readonly IBlogRepository _repository;

        public GetTagsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<List<string>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetTags());           
        }
    }
}
