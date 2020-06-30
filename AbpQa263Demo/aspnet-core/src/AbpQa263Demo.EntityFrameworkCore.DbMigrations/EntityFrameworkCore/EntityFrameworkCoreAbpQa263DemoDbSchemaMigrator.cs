using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpQa263Demo.Data;
using Volo.Abp.DependencyInjection;

namespace AbpQa263Demo.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpQa263DemoDbSchemaMigrator
        : IAbpQa263DemoDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpQa263DemoDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpQa263DemoMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpQa263DemoMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}