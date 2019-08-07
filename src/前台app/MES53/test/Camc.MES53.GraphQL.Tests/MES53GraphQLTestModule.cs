using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Camc.MES53.Configure;
using Camc.MES53.Startup;
using Camc.MES53.Test.Base;

namespace Camc.MES53.GraphQL.Tests
{
    [DependsOn(
        typeof(MES53GraphQLModule),
        typeof(MES53TestBaseModule))]
    public class MES53GraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MES53GraphQLTestModule).GetAssembly());
        }
    }
}