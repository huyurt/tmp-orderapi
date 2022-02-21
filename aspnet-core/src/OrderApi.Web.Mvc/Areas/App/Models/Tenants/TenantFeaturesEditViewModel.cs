using Abp.AutoMapper;
using OrderApi.MultiTenancy;
using OrderApi.MultiTenancy.Dto;
using OrderApi.Web.Areas.App.Models.Common;

namespace OrderApi.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}