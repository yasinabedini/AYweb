using AIPFramework.Queries;
using AYweb.Application.Models.Project.Queries.GetProjects;
using AYweb.Domain.Models.Gallery.Entities;
using AYweb.Domain.Models.Project.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Project.Queries.GetProjectGallery
{
    public class GetProjectGalleryQueryHandler : IQueryHandler<GetProjectGalleryQuery, List<GalleryResult>>
    {
        private readonly IProjectRepository _repository;
        private readonly IMapperAdapter _mapper;

        public GetProjectGalleryQueryHandler(IMapperAdapter mapper, IProjectRepository repository)
        {            
            _mapper = mapper;
            _repository = repository;
        }

        public Task<List<GalleryResult>> Handle(GetProjectGalleryQuery request, CancellationToken cancellationToken)
        {
            var projects = _repository.GetList();
            var galleries = _mapper.Map<List<Gallery>, List<GalleryResult>>(projects.SelectMany(t=>t.Galleries).ToList());


            return Task.FromResult(galleries);
        }
    }
}
