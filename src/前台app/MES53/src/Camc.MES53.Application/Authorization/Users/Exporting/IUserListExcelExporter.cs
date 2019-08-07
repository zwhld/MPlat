using System.Collections.Generic;
using Camc.MES53.Authorization.Users.Dto;
using Camc.MES53.Dto;

namespace Camc.MES53.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}