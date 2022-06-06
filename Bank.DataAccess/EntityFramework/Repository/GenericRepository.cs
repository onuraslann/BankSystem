using Bank.Core.BaseRepository.Abstract;
using Bank.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DataAccess.EntityFramework.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;//veritabanı ile ilgili işlem yapacağız
        private readonly DbSet<TEntity> _dbset; //Tablolar üzerinde işlem yapabilmek için


        public GenericRepository(BankContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }


        public async Task AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
            {

                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;

        }

      

        public void Remove(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {

            return _dbset.Where(expression);


        }


    }
}
