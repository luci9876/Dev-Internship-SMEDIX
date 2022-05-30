using Microsoft.EntityFrameworkCore;
using Smedix.RecruitmentFunnel.Context;

namespace Smedix.RecruitmentFunnel.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected RecruitmentContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(RecruitmentContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
