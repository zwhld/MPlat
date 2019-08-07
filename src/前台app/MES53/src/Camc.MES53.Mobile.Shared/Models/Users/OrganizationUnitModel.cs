using Abp.AutoMapper;
using Camc.MES53.Organizations.Dto;

namespace Camc.MES53.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}