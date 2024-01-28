using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.CallSuccessCounseling
{
    public class CallSuccessCounselingCommandHandler : ICommandHandler<CallSuccessCounselingCommand>
    {
        private readonly ICounselingRepository _repository;

        public CallSuccessCounselingCommandHandler(ICounselingRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CallSuccessCounselingCommand request, CancellationToken cancellationToken)
        {
            _repository.CallSuccess(request.Id);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
