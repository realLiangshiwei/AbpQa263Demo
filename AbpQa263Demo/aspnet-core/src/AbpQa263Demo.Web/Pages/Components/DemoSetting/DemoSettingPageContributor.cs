using System.Threading.Tasks;
using AbpQa263Demo.Localization;
using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.Users;

namespace AbpQa263Demo.Web.Pages.Components.DemoSetting
{
    public class DemoSettingPageContributor : ISettingPageContributor
    {
        public async Task ConfigureAsync(SettingPageCreationContext context)
        {
            if (await CheckPermissionsAsync(context))
            {
                var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpQa263DemoResource>>();
                context.Groups.Add(
                    new SettingPageGroup(
                        "Demo.Setting",
                        "DemoSetting",
                        typeof(DemoSettingGroupViewComponent)
                    )
                );
            }
        }

        public Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            return Task.FromResult(currentUser.IsAuthenticated);
        }
    }
}
