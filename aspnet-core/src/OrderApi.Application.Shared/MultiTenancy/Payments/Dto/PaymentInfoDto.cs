﻿using OrderApi.Editions.Dto;

namespace OrderApi.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < OrderApiConsts.MinimumUpgradePaymentAmount;
        }
    }
}
