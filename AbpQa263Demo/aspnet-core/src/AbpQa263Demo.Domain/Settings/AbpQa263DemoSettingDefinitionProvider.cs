using Volo.Abp.Settings;

namespace AbpQa263Demo.Settings
{
    public class AbpQa263DemoSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpQa263DemoSettings.MySetting1));

            var userSetting = new SettingDefinition(AbpQa263DemoSettings.ExampleSetting);

            userSetting.Properties[AbpQa263DemoConsts.SettingPermissionNames] = new[]
                {"AbpQa263Demo.HostUserPermission", "AbpQa263Demo.UserPermission"};

            context.Add(userSetting);
        }
    }
}
