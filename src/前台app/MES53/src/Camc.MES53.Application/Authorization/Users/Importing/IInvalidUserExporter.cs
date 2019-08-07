using System.Collections.Generic;
using Camc.MES53.Authorization.Users.Importing.Dto;
using Camc.MES53.Dto;

namespace Camc.MES53.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
