using System.Collections.Generic;
using OrderApi.Caching.Dto;

namespace OrderApi.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}