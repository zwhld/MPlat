using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Camc.MES53.Authorization.Users;
using Camc.MES53.MultiTenancy;

namespace Camc.MES53.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}