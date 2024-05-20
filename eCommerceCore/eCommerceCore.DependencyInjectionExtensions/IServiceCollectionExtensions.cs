
using eCommerceCore.Services;
using eCommerceCore.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.DependencyInjectionExtensions
{
    public static class IServiceCollectionExtensions
    { 
        public static void RegisterServicesAndRepositories(this IServiceCollection services)
        {
            services.Scan(selector => selector
                .FromAssemblies(
                  typeof(IAccountTypeService).Assembly,
                  typeof(IUnitOfWork).Assembly
                ).AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
