using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddGroup
{
    public class AddGroupToBlogCommandHandler : ICommandHandler<AddGroupToBlogCommand>
    {
        private readonly IBlogRepository _repository;

        public AddGroupToBlogCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

      
        public Task Handle(AddGroupToBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetById(request.BlogId);
            blog.AddGroup(request.GroupId);

            _repository.Update(blog);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
