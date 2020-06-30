using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpQa263Demo.Data
{
    /* This is used if database provider does't define
     * IAbpQa263DemoDbSchemaMigrator implementation.
     */
    public class NullAbpQa263DemoDbSchemaMigrator : IAbpQa263DemoDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}