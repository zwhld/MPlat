using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Camc.MES53.Dto;

namespace Camc.MES53.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
