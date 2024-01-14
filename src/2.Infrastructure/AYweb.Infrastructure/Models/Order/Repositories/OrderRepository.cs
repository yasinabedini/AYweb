using AYweb.Domain.Models.Order.Repositories;

namespace AYweb.Infrastructure.Models.Order.Repositories;

public class OrderRepository : IOrderRepository
{
    public void Add(Domain.Models.Order.Entities.Order entity)
    {
        throw new NotImplementedException();
    }

    public Domain.Models.Order.Entities.Order GetById(long id)
    {
        throw new NotImplementedException();
    }

    public List<Domain.Models.Order.Entities.Order> GetList()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.Models.Order.Entities.Order entity)
    {
        throw new NotImplementedException();
    }
}
