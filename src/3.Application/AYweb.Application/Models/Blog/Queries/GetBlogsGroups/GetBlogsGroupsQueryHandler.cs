using AIPFramework.Queries;
using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Blog.Repositories;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Blog.Queries.GetBlogsGroups
{
    public class GetBlogsGroupsQueryHandler : IQueryHandler<GetBlogsGroupsQuery, List<BlogGroupResult>>
    {
        private readonly IBlogGroupRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetBlogsGroupsQueryHandler(IBlogGroupRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<BlogGroupResult>> Handle(GetBlogsGroupsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<BlogGroup>, List<BlogGroupResult>>(_repository.GetBlogGroupsByBlogId(request.Id)));
        }
    }
}
