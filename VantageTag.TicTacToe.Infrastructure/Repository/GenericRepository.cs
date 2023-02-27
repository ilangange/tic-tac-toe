using Microsoft.EntityFrameworkCore;
using VantageTag.TicTacToe.Core.Interfaces;
using VantageTag.TicTacToe.Infrastructure.Persistence;

namespace VantageTag.TicTacToe.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private VantageTagDBContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(VantageTagDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _dbSet.AsQueryable<T>();
        }

        public async Task InsertAsync(T entity)
        {
            _dbSet.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
