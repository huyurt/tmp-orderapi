using System.Threading.Tasks;
using Abp.Application.Services;
using OrderApi.Configuration.Tenants.Dto;

namespace OrderApi.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
