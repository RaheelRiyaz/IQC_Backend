using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Domain.Models;
using Iqra_Quran_Center.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity ,new()
    {
        private readonly DbSet<T> dbSet;
        protected readonly IqraQuranCenterDbContext dbContext;

        public BaseRepository(IqraQuranCenterDbContext dbContext)
        {
            dbSet = dbContext.Set<T>();
            this.dbContext = dbContext;
        }


        public async Task<int> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            dbSet.Remove(new T() { Id = id});
            return await SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => dbSet.Where(predicate));
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => dbSet);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AnyAsync(predicate);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            return await SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            dbSet.AddRangeAsync(entities);
            return await SaveChangesAsync();
        }



        #region Utilis
        private async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();

       
        #endregion Utilis
    }
}
