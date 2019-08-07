using System.Threading.Tasks;

namespace Camc.MES53.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}