using neogym.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neogym.business.Servicecs
{
    public interface ITrainerService
    {
        Task CreateAsync(Trainer trainer);
        Task UpdateAsync(Trainer trainer);
        Task DeleteAsync(int id);
        Task<List<Trainer>> GetAllAsync();
        Task<Trainer> GetByIdAsync(int id);

    }
}
