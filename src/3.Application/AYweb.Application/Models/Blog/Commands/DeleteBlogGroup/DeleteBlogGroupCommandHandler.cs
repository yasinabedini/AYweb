using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.DeleteBlogGroup
{
    public class DeleteBlogGroupCommandHandler : ICommandHandler<DeleteBlogGroupCommand>
    {
        private readonly IBlogGroupRepository _repository;

        public DeleteBlogGroupCommandHandler(IBlogGroupRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteBlogGroupCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.CompletedTask;

        }
    }
}
