using Microsoft.Extensions.DependencyInjection;
using neogym.core.Repositories;
using neogym.data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neogym.data
{
    public static class ServiceRegistration
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ITrainerRepository,TrainerRepositpory>();
        }

    }
    
}
