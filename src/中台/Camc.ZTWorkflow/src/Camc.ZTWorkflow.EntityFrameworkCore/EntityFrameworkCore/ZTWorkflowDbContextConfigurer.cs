using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Camc.ZTWorkflow.EntityFrameworkCore
{
    public static class ZTWorkflowDBContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ZTWorkflowDBContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ZTWorkflowDBContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}