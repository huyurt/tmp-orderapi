using System.Collections.Generic;
using Abp.Application.Services.Dto;
using OrderApi.Authorization.Permissions.Dto;
using OrderApi.Web.Areas.App.Models.Common;

namespace OrderApi.Web.Areas.App.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}