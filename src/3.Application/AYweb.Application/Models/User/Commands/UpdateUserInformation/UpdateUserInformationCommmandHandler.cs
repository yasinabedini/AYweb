using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommmandHandler : ICommandHandler<UpdateUserInformationCommmand>
    {
        private readonly IUserRepository _repository;

        public UpdateUserInformationCommmandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateUserInformationCommmand request, CancellationToken cancellationToken)
        {
            _repository.ChangeFirstName(request.Id,request.FirstName);
            _repository.ChangeLastName(request.Id,request.LastName);
            _repository.ChangeEmail(request.Id, request.Email??"");
            _repository.Save();
            
            return Task.CompletedTask;
        }
    }
}
