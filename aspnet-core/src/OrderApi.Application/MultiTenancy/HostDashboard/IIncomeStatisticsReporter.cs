using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.MultiTenancy.HostDashboard.Dto;

namespace OrderApi.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}