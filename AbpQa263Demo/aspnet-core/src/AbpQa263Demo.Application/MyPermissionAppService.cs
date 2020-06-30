using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace AbpQa263Demo
{
    [Authorize]
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IPermissionAppService))]
    public class MyPermissionAppService : PermissionAppService
    {
        public MyPermissionAppService(IPermissionManager permissionManager, IPermissionDefinitionManager permissionDefinitionManager, IOptions<PermissionManagementOptions> options) : base(permissionManager, permissionDefinitionManager, options)
        {
        }

        public override async Task<GetPermissionListResultDto> GetAsync(string providerName, string providerKey)
        {
            var isHostPermission = CurrentUser.UserName == "HostUser";

            await CheckProviderPolicy(providerName);

            var result = new GetPermissionListResultDto
            {
                EntityDisplayName = providerKey,
                Groups = new List<PermissionGroupDto>()
            };

            var multiTenancySide = CurrentTenant.GetMultiTenancySide();

            foreach (var group in PermissionDefinitionManager.GetGroups().WhereIf(!isHostPermission, x=>
                !x.Properties.ContainsKey(AbpQa263DemoConsts.IsHostPermission) ||
                (bool)x.Properties[AbpQa263DemoConsts.IsHostPermission] ==isHostPermission ))
            {
                var groupDto = new PermissionGroupDto
                {
                    Name = group.Name,
                    DisplayName = group.DisplayName.Localize(StringLocalizerFactory),
                    Permissions = new List<PermissionGrantInfoDto>()
                };

                foreach (var permission in group.GetPermissionsWithChildren().WhereIf(!isHostPermission,x=>
                    !x.Properties.ContainsKey(AbpQa263DemoConsts.IsHostPermission) ||
                    (bool)x.Properties[AbpQa263DemoConsts.IsHostPermission] ==isHostPermission ))
                {
                    if (!permission.IsEnabled)
                    {
                        continue;
                    }

                    if (permission.Providers.Any() && !permission.Providers.Contains(providerName))
                    {
                        continue;
                    }

                    if (!permission.MultiTenancySide.HasFlag(multiTenancySide))
                    {
                        continue;
                    }

                    var grantInfoDto = new PermissionGrantInfoDto
                    {
                        Name = permission.Name,
                        DisplayName = permission.DisplayName.Localize(StringLocalizerFactory),
                        ParentName = permission.Parent?.Name,
                        AllowedProviders = permission.Providers,
                        GrantedProviders = new List<ProviderInfoDto>()
                    };

                    var grantInfo = await PermissionManager.GetAsync(permission.Name, providerName, providerKey);

                    grantInfoDto.IsGranted = grantInfo.IsGranted;

                    foreach (var provider in grantInfo.Providers)
                    {
                        grantInfoDto.GrantedProviders.Add(new ProviderInfoDto
                        {
                            ProviderName = provider.Name,
                            ProviderKey = provider.Key,
                        });
                    }

                    groupDto.Permissions.Add(grantInfoDto);
                }

                if (groupDto.Permissions.Any())
                {
                    result.Groups.Add(groupDto);
                }
            }

            return result;
        }
    }
}
