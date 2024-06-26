﻿using AIPFramework.Commands;
using AYweb.Domain.Models.User.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ChangeEmail;

public class ChangeEmailCommandHandler : ICommandHandler<ChangeEmailCommand>
{
    private readonly IUserRepository _repository;

    public ChangeEmailCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        _repository.ChangeEmail(request.Id, request.Email);
        _repository.Save();

        return Task.CompletedTask;
    }
}
