using AbpQa263Demo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpQa263Demo.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpQa263DemoEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpQa263DemoApplicationContractsModule)
        )]
    public class AbpQa263DemoDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
