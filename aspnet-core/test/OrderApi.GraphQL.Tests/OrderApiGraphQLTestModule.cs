using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OrderApi.Configure;
using OrderApi.Startup;
using OrderApi.Test.Base;

namespace OrderApi.GraphQL.Tests
{
    [DependsOn(
        typeof(OrderApiGraphQLModule),
        typeof(OrderApiTestBaseModule))]
    public class OrderApiGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiGraphQLTestModule).GetAssembly());
        }
    }
}