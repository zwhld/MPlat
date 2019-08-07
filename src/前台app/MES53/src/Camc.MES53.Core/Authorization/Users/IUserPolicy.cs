using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Camc.MES53.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
