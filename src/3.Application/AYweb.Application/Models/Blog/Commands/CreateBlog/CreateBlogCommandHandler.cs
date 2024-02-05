using AIPFramework.Commands;
using AYweb.Application.Generators;
using AYweb.Application.Tools;
using AYweb.Domain.Models.Blog.Repositories;
using Castle.Facilities.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Blog.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : ICommandHandler<CreateBlogCommand,long>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapperAdapter _mapper;

        public CreateBlogCommandHandler(IBlogRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<long> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Blog.Entities.Blog blog = Domain.Models.Blog.Entities.Blog.Create();
            blog = _mapper.Map<CreateBlogCommand, Domain.Models.Blog.Entities.Blog>(request);

            FileTools file = new();
            string imageName;

            imageName = Generator.CreateUniqueText(10) + Path.GetExtension(request.Image.FileName);
            file.SaveImage(request.Image, imageName, "blog-image", false);

            blog.ChangeImageName(imageName);

            _repository.Add(blog);
            _repository.Save();

            foreach (var picture in request.Pictures)
            {
                imageName = Generator.CreateUniqueText(10) + Path.GetExtension(picture.FileName);
                file.SaveImage(picture, imageName, "blog-gallery", false);
                blog.Galleries.Add(Domain.Models.Gallery.Entities.Gallery.Create(imageName));
            }


            _repository.Update(blog);
            _repository.Save();
            return Task.FromResult(blog.Id);
        }
    }
}
