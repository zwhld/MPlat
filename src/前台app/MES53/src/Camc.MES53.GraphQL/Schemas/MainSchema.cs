using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using Camc.MES53.Queries.Container;

namespace Camc.MES53.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}