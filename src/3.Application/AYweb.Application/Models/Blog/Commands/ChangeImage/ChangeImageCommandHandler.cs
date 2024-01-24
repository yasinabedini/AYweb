using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.ChangeImage
{
    public class ChangeImageCommandHandler : ICommandHandler<ChangeImageCommand>
    {
        private readonly IBlogRepository _repository;

        public ChangeImageCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeImageCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeImage(request.Id, request.ImageName);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
