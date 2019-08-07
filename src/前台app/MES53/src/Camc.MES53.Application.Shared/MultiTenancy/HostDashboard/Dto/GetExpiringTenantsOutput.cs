using System.Collections.Generic;

namespace Camc.MES53.MultiTenancy.HostDashboard.Dto
{
    public class GetExpiringTenantsOutput
    {
        public List<ExpiringTenant> ExpiringTenants { get; set; }

        public GetExpiringTenantsOutput(List<ExpiringTenant> expiringTenants)
        {
            ExpiringTenants = expiringTenants;
        }
    }
}