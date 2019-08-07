using Abp.AutoMapper;
using Camc.MES53.MultiTenancy.Dto;

namespace Camc.MES53.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}