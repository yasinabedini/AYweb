using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddTag
{
    public class AddTagCommandHandler : ICommandHandler<AddTagCommand>
    {
        private readonly IBlogRepository _repository;

        public AddTagCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddTagCommand request, CancellationToken cancellationToken)
        {
            _repository.AddTagToBlog(request.BlogId, request.Tag);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
