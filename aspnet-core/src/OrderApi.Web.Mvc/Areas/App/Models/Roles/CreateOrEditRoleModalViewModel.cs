using Abp.AutoMapper;
using OrderApi.Authorization.Roles.Dto;
using OrderApi.Web.Areas.App.Models.Common;

namespace OrderApi.Web.Areas.App.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}