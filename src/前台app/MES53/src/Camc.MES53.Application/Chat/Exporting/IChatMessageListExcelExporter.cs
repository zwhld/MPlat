using System.Collections.Generic;
using Camc.MES53.Chat.Dto;
using Camc.MES53.Dto;

namespace Camc.MES53.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(List<ChatMessageExportDto> messages);
    }
}
