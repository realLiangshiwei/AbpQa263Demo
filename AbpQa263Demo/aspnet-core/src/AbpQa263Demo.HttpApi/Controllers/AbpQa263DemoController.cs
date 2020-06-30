using AbpQa263Demo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpQa263Demo.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpQa263DemoController : AbpController
    {
        protected AbpQa263DemoController()
        {
            LocalizationResource = typeof(AbpQa263DemoResource);
        }
    }
}