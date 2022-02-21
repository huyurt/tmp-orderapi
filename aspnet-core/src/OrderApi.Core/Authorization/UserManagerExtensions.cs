using System.Threading.Tasks;
using Abp.Authorization.Users;
using OrderApi.Authorization.Users;

namespace OrderApi.Authorization
{
    public static class UserManagerExtensions
    {
        public static async Task<User> GetAdminAsync(this UserManager userManager)
        {
            return await userManager.FindByNameAsync(AbpUserBase.AdminUserName);
        }
    }
}
