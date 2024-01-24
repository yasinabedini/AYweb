using AIPFramework.Commands;
using AIPFramework.Queries;
using AYweb.Application.Models.Project.Queries.GetProjectGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Gallery.Queries.GetGallery
{
    public class GetGalleryQuery:IQuery<GalleryResult>
    {
        public long Id { get; set; }
    }
}
