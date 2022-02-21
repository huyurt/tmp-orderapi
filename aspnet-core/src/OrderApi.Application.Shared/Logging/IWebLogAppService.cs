using Abp.Application.Services;
using OrderApi.Dto;
using OrderApi.Logging.Dto;

namespace OrderApi.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
