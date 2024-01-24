using AIPFramework.Commands;
using AYweb.Application.Models.Product.Commands.DisableIsSpecial;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.EnableIsSpecial
{
    public class EnableIsSpecialCommandHandler : ICommandHandler<EnableIsSpecialCommand>
    {
        private readonly IProductRepository _repository;

        public EnableIsSpecialCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(EnableIsSpecialCommand request, CancellationToken cancellationToken)
        {
            _repository.EnableIsSpecial(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
