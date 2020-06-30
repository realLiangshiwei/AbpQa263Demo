using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpQa263Demo.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpQa263DemoEntityFrameworkCoreModule)
        )]
    public class AbpQa263DemoEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpQa263DemoMigrationsDbContext>();
        }
    }
}
