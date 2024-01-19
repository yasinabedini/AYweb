using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.ChangeIntroduction
{
    public class ChangeIntroductionCommandHandler : ICommandHandler<ChangeIntroductionCommand>
    {
        private readonly IBlogRepository _repository;

        public ChangeIntroductionCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeIntroductionCommand request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetById(request.Id);
            blog.ChangeIntroduction(request.Introduction);

            _repository.Update(blog);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
