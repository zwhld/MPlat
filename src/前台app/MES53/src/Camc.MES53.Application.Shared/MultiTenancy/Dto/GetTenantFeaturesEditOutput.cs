using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Camc.MES53.Editions.Dto;

namespace Camc.MES53.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}