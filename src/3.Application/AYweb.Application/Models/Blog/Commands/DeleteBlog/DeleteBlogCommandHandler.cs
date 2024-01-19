using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : ICommandHandler<DeleteBlogCommand>
    {
        private readonly IBlogRepository _repository;

        public DeleteBlogCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
