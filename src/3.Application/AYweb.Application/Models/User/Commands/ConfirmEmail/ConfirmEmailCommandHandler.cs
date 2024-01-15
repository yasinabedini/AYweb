﻿using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : ICommandHandler<ConfirmEmailCommand>
    {
        private readonly IUserRepository _repository;

        public ConfirmEmailCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetById(request.Id);
            user.ConfirmEmail();

            _repository.Update(user);
            _repository.Save();
            
            return Task.CompletedTask;
        }
    }
}
