using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Camc.MES53.Configuration.Host.Dto;
using Camc.MES53.Editions.Dto;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}