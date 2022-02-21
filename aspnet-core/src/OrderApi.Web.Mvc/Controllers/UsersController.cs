﻿using Abp.AspNetCore.Mvc.Authorization;
using OrderApi.Authorization;
using OrderApi.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace OrderApi.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}