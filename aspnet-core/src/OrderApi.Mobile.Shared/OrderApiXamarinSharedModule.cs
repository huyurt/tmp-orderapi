﻿using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OrderApi
{
    [DependsOn(typeof(OrderApiClientModule), typeof(AbpAutoMapperModule))]
    public class OrderApiXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApiXamarinSharedModule).GetAssembly());
        }
    }
}