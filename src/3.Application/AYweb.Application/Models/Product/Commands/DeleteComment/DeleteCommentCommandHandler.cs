using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : ICommandHandler<DeleteCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public DeleteCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
