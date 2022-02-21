using System.Threading.Tasks;
using Abp.Application.Services;
using OrderApi.Editions.Dto;
using OrderApi.MultiTenancy.Dto;

namespace OrderApi.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}