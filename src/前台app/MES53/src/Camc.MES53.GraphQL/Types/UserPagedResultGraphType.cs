using Abp.Application.Services.Dto;
using GraphQL.Types;
using Camc.MES53.Dto;

namespace Camc.MES53.Types
{
    public class UserPagedResultGraphType : ObjectGraphType<PagedResultDto<UserDto>>
    {
        public UserPagedResultGraphType()
        {
            Field(x => x.TotalCount);
            Field(x => x.Items, type: typeof(ListGraphType<UserType>));
        }
    }
}