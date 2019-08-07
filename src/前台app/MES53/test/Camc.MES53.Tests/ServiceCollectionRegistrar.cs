//using Abp.Dependency;
//using Castle.MicroKernel.Registration;
//using Castle.Windsor.MsDependencyInjection;
//using Microsoft.Data.Sqlite;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Camc.MES53.EntityFrameworkCore;
//using Camc.MES53.Identity;

//namespace Camc.MES53.Tests
//{
//    public static class ServiceCollectionRegistrar
//    {
//        public static void Register(IIocManager iocManager)
//        {
//            RegisterIdentity(iocManager);

//            var builder = new DbContextOptionsBuilder<MES53DbContext>();

//            var inMemorySqlite = new SqliteConnection("Data Source=:memory:");
//            builder.UseSqlite(inMemorySqlite);

//            iocManager.IocContainer.Register(
//                Component
//                    .For<DbContextOptions<MES53DbContext>>()
//                    .Instance(builder.Options)
//                    .LifestyleSingleton()
//            );

//            inMemorySqlite.Open();

//            new MES53DbContext(builder.Options).Database.EnsureCreated();
//        }

//        private static void RegisterIdentity(IIocManager iocManager)
//        {
//            var services = new ServiceCollection();

//            IdentityRegistrar.Register(services);

//            WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);
//        }
//    }
//}
