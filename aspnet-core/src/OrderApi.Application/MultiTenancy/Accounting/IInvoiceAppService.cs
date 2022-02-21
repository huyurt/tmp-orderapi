using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using OrderApi.MultiTenancy.Accounting.Dto;

namespace OrderApi.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
