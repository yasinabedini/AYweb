using AIPFramework.Commands;
using AYweb.Domain.Models.Gallery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Gallery.Commands.CreateGallery
{
    public class CreateGalleryCommandHandler : ICommandHandler<CreateGalleryCommand>
    {
        private readonly IGalleryRepository _repository;

        public CreateGalleryCommandHandler(IGalleryRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.Gallery.Entities.Gallery.Create(request.ImageName));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
