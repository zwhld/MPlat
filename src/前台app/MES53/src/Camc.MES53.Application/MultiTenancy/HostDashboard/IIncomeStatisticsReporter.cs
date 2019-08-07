using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Camc.MES53.MultiTenancy.HostDashboard.Dto;

namespace Camc.MES53.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}