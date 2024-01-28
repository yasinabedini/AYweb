using AIPFramework.Queries;

namespace AYweb.Application.Models.Gallery.Queries.GetGallery
{
    public class GetGalleryQuery:IQuery<GalleryResult>
    {
        public long Id { get; set; }
    }
}
