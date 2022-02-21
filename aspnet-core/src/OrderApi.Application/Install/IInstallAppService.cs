using System.Threading.Tasks;
using Abp.Application.Services;
using OrderApi.Install.Dto;

namespace OrderApi.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}