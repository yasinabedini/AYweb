using AIPFramework.Commands;
using AYweb.Domain.Models.Gallery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Gallery.Commands.DeleteGallery
{
    public class DeleteGalleryCommandHandler : ICommandHandler<DeleteGalleryCommand>
    {
        private readonly IGalleryRepository _repository;

        public DeleteGalleryCommandHandler(IGalleryRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
