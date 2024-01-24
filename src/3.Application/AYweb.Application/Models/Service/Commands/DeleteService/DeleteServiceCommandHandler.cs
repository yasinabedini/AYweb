using AIPFramework.Commands;
using AYweb.Domain.Models.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Service.Commands.DeleteService
{
    public class DeleteServiceCommandHandler : ICommandHandler<DeleteServiceCommand>
    {
        private readonly IServiceRepository _repository;

        public DeleteServiceCommandHandler(IServiceRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

                return Task.CompletedTask;
        }
    }
}
