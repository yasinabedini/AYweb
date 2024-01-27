using AIPFramework.Commands;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Application.Security;
using AYweb.Domain.Models.User.Repositories;
using MediatR;
using Zamin.Extensions.ObjectMappers.Abstractions;

namespace AYweb.Application.Models.User.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, UserResult>
    {
        private readonly IMapperAdapter _mapper;
        private readonly IUserRepository _repository;
        private readonly ISender _sender;

        public LoginCommandHandler(IUserRepository repository, IMapperAdapter mapper, ISender sender)
        {
            _repository = repository;
            _mapper = mapper;
            _sender = sender;
        }

        public Task<UserResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var hashPass = PasswordHelper.EncodePasswordMd5(request.Password);
            return Task.FromResult(_mapper.Map<Domain.Models.User.Entities.User, UserResult>(_repository.Login(request.PhoneNumber, hashPass)));
        }
    }
}
