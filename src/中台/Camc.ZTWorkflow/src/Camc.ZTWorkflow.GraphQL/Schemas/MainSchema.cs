using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using Camc.ZTWorkflow.Queries.Container;

namespace Camc.ZTWorkflow.Schemas
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