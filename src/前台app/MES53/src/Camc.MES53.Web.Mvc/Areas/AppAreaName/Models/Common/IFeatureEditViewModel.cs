using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Camc.MES53.Editions.Dto;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}