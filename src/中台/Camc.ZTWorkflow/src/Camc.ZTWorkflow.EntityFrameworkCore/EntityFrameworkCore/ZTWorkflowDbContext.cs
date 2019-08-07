using Abp.IdentityServer4;
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Abp.EntityFrameworkCore;

namespace Camc.ZTWorkflow.EntityFrameworkCore
{
    public class ZTWorkflowDBContext : AbpDbContext, IAbpPersistedGrantDbContext
    {
		/* Define an IDbSet for each entity of the application */
		

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public ZTWorkflowDBContext(DbContextOptions<ZTWorkflowDBContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
