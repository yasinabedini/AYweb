using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddBlogGroup
{
    public class AddBlogGroupCommandHandler : ICommandHandler<AddBlogGroupCommand>
    {
        private readonly IBlogGroupRepository _repository;

        public AddBlogGroupCommandHandler(IBlogGroupRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddBlogGroupCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(BlogGroup.Create(request.Title));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
