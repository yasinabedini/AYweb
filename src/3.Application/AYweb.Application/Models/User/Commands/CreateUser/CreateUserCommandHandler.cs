using AIPFramework.Commands;
using AYweb.Application.Security;
using AYweb.Domain.Models.User.Repositories;
using MediatR;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, bool>
    {
        private readonly IMapperAdapter _mapper;
        private readonly IUserRepository _repository;
        private readonly ISender _sender;

        public CreateUserCommandHandler(IMapperAdapter mapper, IUserRepository repository, ISender sender)
        {
            _mapper = mapper;
            _repository = repository;
            _sender = sender;
        }

        public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(request.Password);
            request.Password = hashPassword;

            _repository.Add(_mapper.Map<CreateUserCommand, Domain.Models.User.Entities.User>(request));
            _repository.Save();
            return Task.FromResult(true);
        }
    }
}
