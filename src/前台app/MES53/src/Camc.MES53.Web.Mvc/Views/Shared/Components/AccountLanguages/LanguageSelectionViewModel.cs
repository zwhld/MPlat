using System.Collections.Generic;
using Abp.Localization;
using Microsoft.AspNetCore.Http;

namespace Camc.MES53.Web.Views.Shared.Components.AccountLanguages
{
    public class LanguageSelectionViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        public PathString CurrentUrl { get; set; }
    }
}