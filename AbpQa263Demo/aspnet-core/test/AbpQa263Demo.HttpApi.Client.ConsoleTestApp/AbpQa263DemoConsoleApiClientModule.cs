using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AbpQa263Demo.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(AbpQa263DemoHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AbpQa263DemoConsoleApiClientModule : AbpModule
    {
        
    }
}
