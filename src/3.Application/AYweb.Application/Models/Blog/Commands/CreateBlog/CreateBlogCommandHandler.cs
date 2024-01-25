using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Blog.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : ICommandHandler<CreateBlogCommand>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapperAdapter _mapper;

        public CreateBlogCommandHandler(IBlogRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Blog.Entities.Blog blog = Domain.Models.Blog.Entities.Blog.Create();
            blog = _mapper.Map<CreateBlogCommand, Domain.Models.Blog.Entities.Blog>(request);

            _repository.Add(blog);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
