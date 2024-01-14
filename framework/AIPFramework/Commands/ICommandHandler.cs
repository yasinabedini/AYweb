using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPFramework.Commands;

public interface ICommandHandler<TRequest> : IRequestHandler<TRequest> where TRequest : ICommand
{

}

public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : ICommand<TResponse>
{

}
