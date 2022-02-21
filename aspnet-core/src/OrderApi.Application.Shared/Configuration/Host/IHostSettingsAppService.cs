using System.Threading.Tasks;
using Abp.Application.Services;
using OrderApi.Configuration.Host.Dto;

namespace OrderApi.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
