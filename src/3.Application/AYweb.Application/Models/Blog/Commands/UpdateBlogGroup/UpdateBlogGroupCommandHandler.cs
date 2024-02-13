using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.UpdateBlogGroup
{
    public class UpdateBlogGroupCommandHandler : ICommandHandler<UpdateBlogGroupCommand>
    {
        private readonly IBlogGroupRepository _repository;

        public UpdateBlogGroupCommandHandler(IBlogGroupRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateBlogGroupCommand request, CancellationToken cancellationToken)
        {
            var group = _repository.GetById(request.Id);
            group.ChangeTitle(request.Title);
            _repository.Update(group);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
