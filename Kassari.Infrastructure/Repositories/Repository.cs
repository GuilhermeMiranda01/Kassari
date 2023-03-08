using Kassari.Domain.Entities;
using Kassari.Domain.Interfaces;
using KassariV2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassari.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly KassariContext _context;
        public Repository(KassariContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var objList = _context.Set<TEntity>().ToList();
            return objList.Any() ? objList : new List<TEntity>();
        }

        public TEntity GetById(int id)
        {
            var obj = _context.Set<TEntity>().Where(x => x.Id == id);
            return obj.Any() ? obj.FirstOrDefault() : null;
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
    }
}
