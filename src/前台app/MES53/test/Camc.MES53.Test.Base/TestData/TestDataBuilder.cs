using Camc.MES53.EntityFrameworkCore;

namespace Camc.MES53.Test.Base.TestData
{
    public class TestDataBuilder
    {
        private readonly MES53DbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(MES53DbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();
            new TestEditionsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
