using Camc.MES53.Dto;

namespace Camc.MES53.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}