using AYweb.Domain.Models.Product.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Product.Repositories
{
    public class ProductRepository : BaseRepository<Domain.Models.Product.Entities.Product>, IProductRepository
    {
        public ProductRepository(AyWebDbContext context) : base(context)
        {
        }
    }
}
