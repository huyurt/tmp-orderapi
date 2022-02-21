using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OrderApi.Authorization.Permissions.Dto;

namespace OrderApi.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
