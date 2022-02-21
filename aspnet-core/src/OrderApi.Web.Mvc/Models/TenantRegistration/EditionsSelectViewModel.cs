using Abp.AutoMapper;
using OrderApi.MultiTenancy.Dto;

namespace OrderApi.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
