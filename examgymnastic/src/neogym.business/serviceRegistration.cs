using Microsoft.Extensions.DependencyInjection;
using neogym.business.Servicecs;
using neogym.business.Servicecs.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neogym.business
{
    public static class serviceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITrainerService,TrainerService>();
        }
    }
}
