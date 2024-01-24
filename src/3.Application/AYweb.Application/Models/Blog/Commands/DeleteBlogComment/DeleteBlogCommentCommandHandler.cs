using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.DeleteBlogComment
{
    public class DeleteBlogCommentCommandHandler : ICommandHandler<DeleteBlogCommentCommand>
    {
        private readonly IBlogCommentRepository _repository;

        public DeleteBlogCommentCommandHandler(IBlogCommentRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteBlogCommentCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
