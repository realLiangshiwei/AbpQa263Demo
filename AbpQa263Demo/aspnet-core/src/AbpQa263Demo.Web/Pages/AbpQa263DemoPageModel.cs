using AbpQa263Demo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpQa263Demo.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AbpQa263DemoPageModel : AbpPageModel
    {
        protected AbpQa263DemoPageModel()
        {
            LocalizationResourceType = typeof(AbpQa263DemoResource);
        }
    }
}