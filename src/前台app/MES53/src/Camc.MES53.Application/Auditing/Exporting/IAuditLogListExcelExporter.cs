using System.Collections.Generic;
using Camc.MES53.Auditing.Dto;
using Camc.MES53.Dto;

namespace Camc.MES53.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
