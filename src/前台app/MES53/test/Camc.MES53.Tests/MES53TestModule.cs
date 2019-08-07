using Abp.Modules;
using Camc.MES53.Test.Base;

namespace Camc.MES53.Tests
{
    [DependsOn(typeof(MES53TestBaseModule))]
    public class MES53TestModule : AbpModule
    {
       
    }
}
