using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Camc.MES53.Sessions.Dto;

namespace Camc.MES53.Models.Common
{
    [AutoMapFrom(typeof(TenantLoginInfoDto)),
     AutoMapTo(typeof(TenantLoginInfoDto))]
    public class TenantLoginInfoPersistanceModel : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}