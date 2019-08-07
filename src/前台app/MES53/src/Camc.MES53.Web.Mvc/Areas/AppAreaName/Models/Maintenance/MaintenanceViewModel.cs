using System.Collections.Generic;
using Camc.MES53.Caching.Dto;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}