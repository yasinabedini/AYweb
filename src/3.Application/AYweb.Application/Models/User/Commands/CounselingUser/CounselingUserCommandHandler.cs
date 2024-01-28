using AIPFramework.Commands;
using AYweb.Application.Senders;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.CounselingUser
{
    public class CounselingUserCommandHandler : ICommandHandler<CounselingUserCommand>
    {
        private readonly ICounselingRepository _repository;

        public CounselingUserCommandHandler(ICounselingRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CounselingUserCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.User.Entities.Counseling.Create(request.UserName, request.PhoneNumber, request.Message, request.Title, ""));
            _repository.Save();

            Sms.CounselingRequest(request.PhoneNumber,request.UserName);

            return Task.CompletedTask;
        }
    }
}
