using System;
using System.Collections.Generic;
using System.Text;
using AbpQa263Demo.Localization;
using Volo.Abp.Application.Services;

namespace AbpQa263Demo
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpQa263DemoAppService : ApplicationService
    {
        protected AbpQa263DemoAppService()
        {
            LocalizationResource = typeof(AbpQa263DemoResource);
        }
    }
}
