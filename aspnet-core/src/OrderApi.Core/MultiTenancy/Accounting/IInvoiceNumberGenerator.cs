using System.Threading.Tasks;
using Abp.Dependency;

namespace OrderApi.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}