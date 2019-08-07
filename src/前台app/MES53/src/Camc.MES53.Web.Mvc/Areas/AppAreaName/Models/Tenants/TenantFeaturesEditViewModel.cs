using Abp.AutoMapper;
using Camc.MES53.MultiTenancy;
using Camc.MES53.MultiTenancy.Dto;
using Camc.MES53.Web.Areas.AppAreaName.Models.Common;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}