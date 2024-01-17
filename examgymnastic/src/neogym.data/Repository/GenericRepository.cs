using Microsoft.EntityFrameworkCore;
using neogym.core.Models;
using neogym.core.Repositories;
using neogym.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace neogym.data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public   async Task<int> CommitAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public  IQueryable<TEntity> GetAllAsync(Expression<Func<TEntity, bool>>? expression, params string[]? include)
        {
            var query = GetQuery(include);

            return expression is not null
                ?query.Where(expression)
                : query;
        }

        public  async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression, params string[]? include)
        {
            var query = GetQuery(include);
            return expression is not null
                ? await  query.Where(expression).FirstOrDefaultAsync()
                :await query.FirstOrDefaultAsync();
        }
        public  IQueryable<TEntity> GetQuery(params string[] includes)
        {
            var query = Table.AsQueryable();
            if(includes.Length>0 && includes == null)
            {
                foreach(var include in includes)
                {
                    query=query.Include(include);
                }
            }
            return query; 
        }
    }
}
