﻿namespace OrderApi.MultiTenancy.Payments.Dto
{
    public class GetActiveGatewaysInput
    {
        public bool? RecurringPaymentsEnabled { get; set; }
    }
}