using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Infrastructure.Repository;
using TaskMenager.Model.Interface;

namespace TaskMenager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.AddTransient<IToDoRepository, ToDoRepository>();
            return services;
        }
    }
}
