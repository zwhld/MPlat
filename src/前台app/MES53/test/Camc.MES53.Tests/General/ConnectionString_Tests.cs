using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace Camc.MES53.Tests.General
{
    // ReSharper disable once InconsistentNaming
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=MES53; Trusted_Connection=True;");
            csb["Database"].ShouldBe("MES53");
        }
    }
}
