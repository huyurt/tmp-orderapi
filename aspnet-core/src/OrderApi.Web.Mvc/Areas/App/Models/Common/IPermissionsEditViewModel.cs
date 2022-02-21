using System.Collections.Generic;
using OrderApi.Authorization.Permissions.Dto;

namespace OrderApi.Web.Areas.App.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}