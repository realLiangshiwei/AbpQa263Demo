using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace AbpQa263Demo.Web
{
    [Dependency(ReplaceServices = true)]
    public class AbpQa263DemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpQa263Demo";
    }
}
