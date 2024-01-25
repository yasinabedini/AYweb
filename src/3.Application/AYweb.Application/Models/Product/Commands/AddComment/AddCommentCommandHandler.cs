using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Entities;
using AYweb.Domain.Models.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.Product.Commands.AddComment
{
    public class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapperAdapter _mapper;

        public AddCommentCommandHandler(ICommentRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = Comment.Create(); ;
            comment = _mapper.Map<AddCommentCommand, Comment>(request);

            _repository.Add(comment);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
