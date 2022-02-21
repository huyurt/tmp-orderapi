using System.Collections.Generic;
using Abp.Application.Services.Dto;
using OrderApi.Editions.Dto;

namespace OrderApi.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}