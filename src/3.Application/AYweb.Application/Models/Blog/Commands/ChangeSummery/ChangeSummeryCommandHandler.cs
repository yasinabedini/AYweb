using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Repositories;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.ChangeSummery
{
    public class ChangeSummeryCommandHandler : ICommandHandler<ChangeSummeryCommand>
    {
        private readonly IBlogRepository _repository;

        public ChangeSummeryCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ChangeSummeryCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeSummery(request.Id, request.Summery);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
