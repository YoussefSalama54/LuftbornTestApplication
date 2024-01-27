using LuftbornTestApplication.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTestApplication.Repositories.Repositories
{
    public class GeneralRepository<TEntity> where TEntity : class
    {
        private readonly MarketPlaceContext dbcontext;

        public GeneralRepository(MarketPlaceContext context)
        {
            dbcontext = context;
        }

        protected virtual IQueryable<TEntity> AsQueryable()
        {
            return dbcontext.Set<TEntity>();
        }

        protected virtual void Delete(TEntity entity)
        {
            dbcontext.Set<TEntity>().Remove(entity);
        }

        protected virtual void Insert(TEntity entity)
        {
            dbcontext.Set<TEntity>().Add(entity);
        }

        protected virtual void Update(TEntity entity)
        {
            dbcontext.Entry(entity).State = EntityState.Modified;
        }
    }
}