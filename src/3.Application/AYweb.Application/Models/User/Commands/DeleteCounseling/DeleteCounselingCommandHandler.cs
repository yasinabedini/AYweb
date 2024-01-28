using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.DeleteCounseling
{
    public class DeleteCounselingCommandHandler : ICommandHandler<DeleteCounselingCommand>
    {
        private readonly ICounselingRepository _repository;

        public DeleteCounselingCommandHandler(ICounselingRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(DeleteCounselingCommand request, CancellationToken cancellationToken)
        {
            _repository.Delete(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
