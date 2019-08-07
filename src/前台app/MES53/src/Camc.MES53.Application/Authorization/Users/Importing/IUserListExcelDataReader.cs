using System.Collections.Generic;
using Camc.MES53.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Camc.MES53.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
