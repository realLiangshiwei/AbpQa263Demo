using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;

namespace AbpQa263Demo
{
    public class DemoAppService : AbpQa263DemoAppService
    {
        private readonly IRepository<Tenant, Guid> _tenantRepository;

        private readonly IRepository<IdentityUser, Guid> _userRepository;


        public DemoAppService(IRepository<Tenant, Guid> tenantRepository, IRepository<IdentityUser, Guid> userRepository)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
        }


        public async Task Set()
        {
            using (CurrentTenant.Change(null))
            {
                var allTenant = await _tenantRepository.GetListAsync();

                foreach (var tenant in allTenant)
                {
                    using (CurrentTenant.Change(tenant.Id))
                    {
                        var user =  await _userRepository.GetListAsync();

                        // to do something...
                    }
                }
            }
        }
    }
}
