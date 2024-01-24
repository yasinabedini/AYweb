using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.ChangeTitle
{
    public class ChangeTitleCommandHandler : ICommandHandler<ChangeTitleCommand>
    {
        private readonly IBlogRepository _repository;

        public ChangeTitleCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeTitleCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeTitle(request.Id,request.Title);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
