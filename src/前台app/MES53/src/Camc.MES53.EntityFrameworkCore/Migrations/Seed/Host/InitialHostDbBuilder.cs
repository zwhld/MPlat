using Camc.MES53.EntityFrameworkCore;

namespace Camc.MES53.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly MES53DbContext _context;

        public InitialHostDbBuilder(MES53DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
