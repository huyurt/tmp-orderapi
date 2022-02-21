using System.Threading.Tasks;
using Abp.Webhooks;

namespace OrderApi.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
