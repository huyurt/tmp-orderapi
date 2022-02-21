using System.Collections.Generic;
using Abp;
using OrderApi.Chat.Dto;
using OrderApi.Dto;

namespace OrderApi.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
