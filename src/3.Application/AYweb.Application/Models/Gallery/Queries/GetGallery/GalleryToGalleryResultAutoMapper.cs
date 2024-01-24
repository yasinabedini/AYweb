using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Gallery.Queries.GetGallery
{
    public class GalleryToGalleryResultAutoMapper:Profile
    {
        public GalleryToGalleryResultAutoMapper() {
            CreateMap<Domain.Models.Gallery.Entities.Gallery, GalleryResult>().ReverseMap();
        }

    }
}
