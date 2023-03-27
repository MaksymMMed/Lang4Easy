using DAL.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Realizations
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly Context context;
        protected readonly DbSet<T> table;

        protected GenericRepository(Context context, DbSet<T> table)
        {
            this.context = context;
            this.table = context.Set<T>();
        }

        public async Task Delete(int id)
        {
            var item = await table.FindAsync(id);
            table.Remove(item);
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public abstract Task<T> GetById(int id);

        public async Task Insert(T entity)
        {
            await table.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            table.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
