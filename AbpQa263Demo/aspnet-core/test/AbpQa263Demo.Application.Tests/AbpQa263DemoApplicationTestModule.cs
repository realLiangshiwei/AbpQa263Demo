using Volo.Abp.Modularity;

namespace AbpQa263Demo
{
    [DependsOn(
        typeof(AbpQa263DemoApplicationModule),
        typeof(AbpQa263DemoDomainTestModule)
        )]
    public class AbpQa263DemoApplicationTestModule : AbpModule
    {

    }
}