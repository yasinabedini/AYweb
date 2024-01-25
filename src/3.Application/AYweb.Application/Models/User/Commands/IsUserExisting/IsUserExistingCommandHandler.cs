using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.IsUserExisting
{
    public class IsUserExistingCommandHandler : ICommandHandler<IsUserExistingCommand, bool>
    {
        private readonly IUserRepository _repository;

        public IsUserExistingCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(IsUserExistingCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.IsUserExisting(request.PhoneNumber));
        }
    }
}
