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
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Domain.Models.Order.Entities.Order>
    {
        private readonly IOrderRepository _repository;
        private readonly IHttpContextAccessor _httpContext;

        public CreateOrderCommandHandler(IOrderRepository repository, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContext = httpContext;
        }

        public Task<Domain.Models.Order.Entities.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Domain.Models.Order.Entities.Order.Create(request.UserId,0);
            _repository.Add(order);
            _repository.Save();

            return Task.FromResult(order);
        }
    }
}
