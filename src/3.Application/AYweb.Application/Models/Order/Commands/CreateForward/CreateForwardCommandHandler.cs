using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.CreateForward
{
    public class CreateForwardCommandHandler : ICommandHandler<CreateForwardCommand, long>
    {
        private readonly IForwardRepository _repository;

        public CreateForwardCommandHandler(IForwardRepository repository)
        {
            _repository = repository;
        }

        public Task<long> Handle(CreateForwardCommand request, CancellationToken cancellationToken)
        {
            var forward = Domain.Models.Order.Entities.Forward.Create(request.OrderId, request.Province, request.City, request.PostalCode, request.Address, request.TransfereeName);
            _repository.Add(forward);
            _repository.Save();

            return Task.FromResult(forward.Id);
        }
    }
}
