using System.Threading.Tasks;
using AbpQa263Demo.Settings;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity.Web;
using Volo.Abp.SettingManagement;

namespace AbpQa263Demo.Web.Pages.Components.DemoSetting
{
    public class DemoSettingGroupViewComponent : AbpViewComponent
    {

        private readonly ISettingManager _settingManager;

        public DemoSettingGroupViewComponent(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = new DemoSettingDto()
            {
                DemoSetting = await _settingManager.GetOrNullForCurrentTenantAsync(AbpQa263DemoSettings.ExampleSetting)
            };


            return View("~/Pages/Components/DemoSetting/Default.cshtml", model);
        }
    }

    public class DemoSettingDto
    {
        public string DemoSetting { get; set; }
    }
}
