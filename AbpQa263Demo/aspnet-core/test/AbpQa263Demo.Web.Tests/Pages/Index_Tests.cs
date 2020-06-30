using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpQa263Demo.Pages
{
    public class Index_Tests : AbpQa263DemoWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
