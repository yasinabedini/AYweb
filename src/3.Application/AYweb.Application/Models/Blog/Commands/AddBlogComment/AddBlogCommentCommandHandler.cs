using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddBlogComment
{
    public class AddBlogCommentCommandHandler : ICommandHandler<AddBlogCommentCommand>
    {
        private readonly IBlogCommentRepository _repository;

        public AddBlogCommentCommandHandler(IBlogCommentRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddBlogCommentCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(BlogComment.Create(request.Text, request.BlogId, request.UserName, request.UserPhoneNumber));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
