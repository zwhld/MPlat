using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Camc.MES53.EntityFrameworkCore
{
    public static class MES53DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MES53DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MES53DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}