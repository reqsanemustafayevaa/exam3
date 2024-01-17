using neogym.core.Models;
using neogym.core.Repositories;
using neogym.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neogym.data.Repository
{
    public class TrainerRepositpory : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepositpory(AppDbContext context) : base(context)
        {
        }
    }
}
