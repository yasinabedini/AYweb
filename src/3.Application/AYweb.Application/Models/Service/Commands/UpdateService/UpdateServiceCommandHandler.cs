using AIPFramework.Commands;
using AYweb.Domain.Models.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Service.Commands.UpdateService
{
    public class UpdateServiceCommandHandler : ICommandHandler<UpdateServiceCommand>
    {
        private readonly IServiceRepository _repository;

        public UpdateServiceCommandHandler(IServiceRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.Service);
            _repository.Save();
            return Task.CompletedTask;
        }
    }
}
