using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Camc.MES53.Configuration.Tenants.Dto;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}