using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpQa263Demo.EntityFrameworkCore
{
    public static class AbpQa263DemoDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpQa263Demo(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpQa263DemoConsts.DbTablePrefix + "YourEntities", AbpQa263DemoConsts.DbSchema);

            //    //...
            //});
        }
    }
}