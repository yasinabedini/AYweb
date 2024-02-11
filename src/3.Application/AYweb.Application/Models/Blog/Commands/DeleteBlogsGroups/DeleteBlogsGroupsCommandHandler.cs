using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.DeleteBlogsGroups
{
    public class DeleteBlogsGroupsCommandHandler : ICommandHandler<DeleteBlogsGroupsCommand>
    {
        private readonly IBlogRepository _repository;

        public DeleteBlogsGroupsCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteBlogsGroupsCommand request, CancellationToken cancellationToken)
        {
            _repository.DeleteBlogsGroups(request.BlogId);

            return Task.CompletedTask;
        }
    }
}
