using AutoMapper;
using AYweb.Domain.Models.Blog.Entities;

namespace AYweb.Application.Models.Blog.Queries.Common
{
    public class CommentToCommentResultAutoMapper : Profile
    {
        public CommentToCommentResultAutoMapper()
        {
            CreateMap<BlogComment, CommentResult>().ReverseMap();
        }
    }
}
