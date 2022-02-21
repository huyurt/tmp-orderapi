using System.Collections.Generic;

namespace OrderApi.Logging.Dto
{
    public class GetLatestWebLogsOutput
    {
        public List<string> LatestWebLogLines { get; set; }
    }
}
