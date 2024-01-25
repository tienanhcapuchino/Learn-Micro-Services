using Core.Domain.Constants;
using Core.Domain.DataContext;
using Core.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Services.DataUpgrade
{
    public class RoleDataUpgradeService : IDataUpgradeService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleDataUpgradeService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task UpgradeAsync()
        {
            await UpgradeRoleAsync();
        }
        public async Task UpgradeRoleAsync()
        {
            foreach (var role in RoleName.UserRoles)
            {
                if (!_roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
