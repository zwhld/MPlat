using Abp.Auditing;
using Camc.MES53.Configuration.Dto;

namespace Camc.MES53.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}