using Microsoft.EntityFrameworkCore;
using neogym.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace neogym.core.Repositories
{
    public interface IGenericRepository<tEntity>where tEntity : BaseEntity,new()
    {
        DbSet<tEntity> Table { get; }
        Task CreateAsync(tEntity entity);
        void Delete(tEntity entity);
        IQueryable<tEntity> GetAllAsync(Expression<Func<tEntity, bool>>? expression=null, params string[]? include);
        Task<tEntity>GetByIdAsync(Expression<Func<tEntity, bool>>? expression=null,params string[]? include);
        Task<int> CommitAsync();


        
    }
}
