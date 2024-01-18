using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.DeleteFeature
{
    public class DeleteFeatureCommandHandler : ICommandHandler<DeleteFeatureCommand>
    {
        private readonly IFeatureRepository _repository;

        public DeleteFeatureCommandHandler(IFeatureRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
