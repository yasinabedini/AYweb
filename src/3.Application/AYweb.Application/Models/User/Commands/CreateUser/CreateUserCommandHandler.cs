using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, bool>
    {
        private readonly IMapperAdapter _mapper;
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IMapperAdapter mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(_mapper.Map<CreateUserCommand, Domain.Models.User.Entities.User>(request));
            _repository.Save();
            return Task.FromResult(true);
        }
    }
}
