﻿using Abp.Application.Services.Dto;
using Abp.Webhooks;
using OrderApi.WebHooks.Dto;

namespace OrderApi.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
