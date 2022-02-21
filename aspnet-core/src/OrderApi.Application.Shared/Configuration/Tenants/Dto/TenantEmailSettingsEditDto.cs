using Abp.Auditing;
using OrderApi.Configuration.Dto;

namespace OrderApi.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}