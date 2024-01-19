using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.ChangeText
{
    public class ChangeTextCommandHandler : ICommandHandler<ChangeTextCommand>
    {
        private readonly IBlogRepository _repository;

        public ChangeTextCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeTextCommand request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetById(request.Id);
            blog.ChangeText(request.Text);

            _repository.Update(blog);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
