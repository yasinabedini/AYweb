using AIPFramework.Commands;
using AYweb.Domain.Models.Order.Entities;
using AYweb.Domain.Models.Order.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public CreateOrderCommandHandler(IOrderRepository repository, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContext = httpContext;
        }

        public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(Domain.Models.Order.Entities.Order.Create(request.UserId));
            _repository.Save();

            return Task.CompletedTask;
        }
    }
}
