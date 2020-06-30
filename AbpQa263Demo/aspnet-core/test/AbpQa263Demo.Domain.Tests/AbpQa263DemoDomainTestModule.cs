using AbpQa263Demo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpQa263Demo
{
    [DependsOn(
        typeof(AbpQa263DemoEntityFrameworkCoreTestModule)
        )]
    public class AbpQa263DemoDomainTestModule : AbpModule
    {

    }
}