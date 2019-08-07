using System.Collections.Generic;
using Abp.Localization;
using Camc.MES53.Install.Dto;

namespace Camc.MES53.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
