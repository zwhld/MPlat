using System.Threading.Tasks;
using Abp.Dependency;

namespace Camc.MES53.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}