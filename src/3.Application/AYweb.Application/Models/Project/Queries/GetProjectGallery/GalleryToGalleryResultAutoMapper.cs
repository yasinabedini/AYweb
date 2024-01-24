using AutoMapper;
using AYweb.Domain.Models.Gallery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Project.Queries.GetProjectGallery
{
    public class GalleryToGalleryResultAutoMapper : Profile
    {
        public GalleryToGalleryResultAutoMapper()
        {
            CreateMap<Domain.Models.Gallery.Entities.Gallery, GalleryResult>().ReverseMap();
        }
    }
}
