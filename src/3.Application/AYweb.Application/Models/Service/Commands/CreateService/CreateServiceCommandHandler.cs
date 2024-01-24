using AIPFramework.Commands;
using AYweb.Domain.Models.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Service.Commands.CreateService
{
    public class CreateServiceCommandHandler : ICommandHandler<CreateServiceCommand>
    {
        private readonly IServiceRepository _repository;

        public CreateServiceCommandHandler(IServiceRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.Service.Entities.Service.Create(request.Title, request.Description, request.Image, request.ParentId));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
