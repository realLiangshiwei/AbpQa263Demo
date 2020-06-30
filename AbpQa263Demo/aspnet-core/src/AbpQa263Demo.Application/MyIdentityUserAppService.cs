using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace AbpQa263Demo
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IIdentityUserAppService))]
    public class MyIdentityUserAppService : IdentityUserAppService
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;

        public MyIdentityUserAppService(IdentityUserManager userManager, IIdentityUserRepository userRepository,
            IRepository<IdentityUser, Guid> userRepository1) : base(userManager, userRepository)
        {
            _userRepository = userRepository1;
        }

        [Authorize(IdentityPermissions.Users.Default)]

        public override async Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            var query = _userRepository
                .Where(u => !EF.Property<bool>(u, "IsHostUser"))
                .WhereIf(!input.Filter.IsNullOrEmpty(),
                    u =>
                        u.UserName.Contains(input.Filter) ||
                        u.PhoneNumber.Contains(input.Filter) ||
                        u.Surname.Contains(input.Filter));

            var count = await query.CountAsync();

            var list = await query.PageBy(input).ToListAsync();

            return new PagedResultDto<IdentityUserDto>(
                count,
                ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(list)
            );
        }
    }
}
