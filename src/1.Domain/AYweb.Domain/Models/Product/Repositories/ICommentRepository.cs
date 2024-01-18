using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Product.Repositories
{
    public interface ICommentRepository:IRepository<Comment>
    {
    }
}
