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
            var blog = _repository.GetById(request.Id);
            blog.ChangeTitle(request.Title);

            _repository.Update(blog);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
