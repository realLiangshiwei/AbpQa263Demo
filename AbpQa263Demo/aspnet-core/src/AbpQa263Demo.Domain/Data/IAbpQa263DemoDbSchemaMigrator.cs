using System.Threading.Tasks;

namespace AbpQa263Demo.Data
{
    public interface IAbpQa263DemoDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
