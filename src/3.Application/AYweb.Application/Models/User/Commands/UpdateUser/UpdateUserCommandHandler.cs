using AIPFramework.Commands;
using AYweb.Domain.Models.Product.Repositories;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(request.User);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
