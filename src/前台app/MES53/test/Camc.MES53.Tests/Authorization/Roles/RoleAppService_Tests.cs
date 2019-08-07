using System.Threading.Tasks;
using Camc.MES53.Authorization.Roles;
using Camc.MES53.Authorization.Roles.Dto;
using Camc.MES53.Test.Base;
using Shouldly;
using Xunit;

namespace Camc.MES53.Tests.Authorization.Roles
{
    // ReSharper disable once InconsistentNaming
    public class RoleAppService_Tests : AppTestBase
    {
        private readonly IRoleAppService _roleAppService;

        public RoleAppService_Tests()
        {
            _roleAppService = Resolve<IRoleAppService>();
        }

        [MultiTenantFact]
        public async Task Should_Get_Roles_For_Host()
        {
            LoginAsHostAdmin();

            //Act
            var output = await _roleAppService.GetRoles(new GetRolesInput());

            //Assert
            output.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_Roles_For_Tenant()
        {
            //Act
            var output = await _roleAppService.GetRoles(new GetRolesInput());

            //Assert
            output.Items.Count.ShouldBe(2);
        }
    }
}
