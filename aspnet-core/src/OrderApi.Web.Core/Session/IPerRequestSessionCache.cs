using System.Threading.Tasks;
using OrderApi.Sessions.Dto;

namespace OrderApi.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
