using AbpQa263Demo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Localization;

namespace AbpQa263Demo.Permissions
{
    public class AbpQa263DemoPermissionDefinitionProvider : PermissionDefinitionProvider
    {


        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpQa263DemoPermissions.GroupName);

            //hidden all children in the group
            myGroup.Properties[AbpQa263DemoConsts.IsHostPermission] = false;

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpQa263DemoPermissions.MyPermission1, L("Permission:MyPermission1"));

            // no hidden
            myGroup.AddPermission(AbpQa263DemoPermissions.UserPermission).Properties[AbpQa263DemoConsts.IsHostPermission] = false;

            // hidden
            myGroup.AddPermission(AbpQa263DemoPermissions.HostUserPermission).Properties[AbpQa263DemoConsts.IsHostPermission] = true;


        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpQa263DemoResource>(name);
        }
    }
}
