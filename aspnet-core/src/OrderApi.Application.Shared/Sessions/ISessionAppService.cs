﻿using System.Threading.Tasks;
using Abp.Application.Services;
using OrderApi.Sessions.Dto;

namespace OrderApi.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
