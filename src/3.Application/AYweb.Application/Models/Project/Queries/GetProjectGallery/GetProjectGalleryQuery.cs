using AIPFramework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Project.Queries.GetProjectGallery
{
    public class GetProjectGalleryQuery:IQuery<List<GalleryResult>>
    {
        public long ProjectId { get; set; }
    }
}
