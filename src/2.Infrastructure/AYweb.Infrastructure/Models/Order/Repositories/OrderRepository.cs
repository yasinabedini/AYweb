using AYweb.Domain.Models.Order.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;

namespace AYweb.Infrastructure.Models.Order.Repositories;

public class OrderRepository : BaseRepository<Domain.Models.Order.Entities.Order>, IOrderRepository
{
    public OrderRepository(AyWebDbContext context) : base(context)
    {
    }
}
