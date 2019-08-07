using System.Threading.Tasks;
using Camc.MES53.Sessions.Dto;

namespace Camc.MES53.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
