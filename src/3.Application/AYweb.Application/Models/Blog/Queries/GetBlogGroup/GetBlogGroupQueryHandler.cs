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

namespace AYweb.Application.Models.Blog.Queries.GetBlogGroup
{
    public class GetBlogGroupQueryHandler : IQueryHandler<GetBlogGroupQuery, BlogGroupResult>
    {
        private readonly IBlogGroupRepository _repository;
        private readonly IMapperAdapter _mapper;


        public GetBlogGroupQueryHandler(IBlogGroupRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BlogGroupResult> Handle(GetBlogGroupQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<BlogGroup, BlogGroupResult>(_repository.GetById(request.Id)));
        }
    }
}
