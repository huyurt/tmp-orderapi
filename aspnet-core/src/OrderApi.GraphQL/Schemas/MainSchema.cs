using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using OrderApi.Queries.Container;
using System;

namespace OrderApi.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}