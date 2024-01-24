using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddGroupToBlog
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
            _repository.AddGroupToBlog(request.BlogId, request.GroupId);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
