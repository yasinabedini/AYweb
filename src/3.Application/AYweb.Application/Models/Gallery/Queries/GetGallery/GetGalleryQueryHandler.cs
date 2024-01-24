using AIPFramework.Queries;
using AYweb.Domain.Models.Gallery.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Gallery.Queries.GetGallery
{
    public class GetGalleryQueryHandler : IQueryHandler<GetGalleryQuery, GalleryResult>
    {
        private readonly IGalleryRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetGalleryQueryHandler(IGalleryRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<GalleryResult> Handle(GetGalleryQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<Domain.Models.Gallery.Entities.Gallery, GalleryResult>(_repository.GetById(request.Id)));
        }
    }
}
