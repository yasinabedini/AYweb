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

namespace AYweb.Application.Models.Blog.Queries.GetBlogGroups
{
    public class GetBlogGroupsQueryHandler : IQueryHandler<GetBlogGroupsQuery, List<BlogGroupResult>>
    {
        private readonly IBlogGroupRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetBlogGroupsQueryHandler(IBlogGroupRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<BlogGroupResult>> Handle(GetBlogGroupsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<BlogGroup>, List<BlogGroupResult>>(_repository.GetList()));
        }
    }
}
