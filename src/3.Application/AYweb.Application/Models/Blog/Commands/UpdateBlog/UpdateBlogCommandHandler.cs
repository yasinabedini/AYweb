using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : ICommandHandler<UpdateBlogCommand>
    {
        private readonly IBlogRepository _repository;

        public UpdateBlogCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
