using AIPFramework.Commands;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Application.Security;
using AYweb.Domain.Models.Product.Repositories;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IMapperAdapter _mapper;

        public UpdateUserCommandHandler(IUserRepository repository, IMapperAdapter mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(request.Id);

            if (!string.IsNullOrEmpty(request.Password))
            {
                user.ChangePassword(PasswordHelper.EncodePasswordMd5(request.Password));
            }

            user.ChangeFirstName(request.FirstName);
            user.ChangeLastName(request.LastName);
            user.ChangeEmail(request.Email ?? "");

            _repository.Update(user);
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
