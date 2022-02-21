using Abp.Authorization;
using OrderApi.Authorization.Roles;
using OrderApi.Authorization.Users;

namespace OrderApi.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
