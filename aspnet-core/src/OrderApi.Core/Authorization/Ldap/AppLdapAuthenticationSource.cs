using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using OrderApi.Authorization.Users;
using OrderApi.MultiTenancy;

namespace OrderApi.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}