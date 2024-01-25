using AIPFramework.Entities;
using AYweb.Domain.Common.Repositories;
using AYweb.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AYweb.Infrastructure.Common.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot  
    {
        private readonly AyWebDbContext _context;        

        public BaseRepository(AyWebDbContext context)
        {
            _context = context;            
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(long id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            entity.IsDelete = true;
            Update(entity);            
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetList()
        {
            return _context.Set<TEntity>().ToList();
        }      

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
     
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
