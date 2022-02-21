using System.Threading.Tasks;
using OrderApi.Authorization.Users;

namespace OrderApi.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
