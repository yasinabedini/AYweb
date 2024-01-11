using AIPFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Common.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(long id);
        void Add(TEntity entity);
        List<TEntity> GetList();
        void Update(TEntity entity);
        void Save();

    }
}
