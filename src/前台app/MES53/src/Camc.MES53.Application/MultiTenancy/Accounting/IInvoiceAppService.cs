using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Camc.MES53.MultiTenancy.Accounting.Dto;

namespace Camc.MES53.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
