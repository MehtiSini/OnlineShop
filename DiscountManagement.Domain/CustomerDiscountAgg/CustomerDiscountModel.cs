﻿using MyFramework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace DiscountManagement.Domain.CusotmerDiscountAgg
{
    public class CustomerDiscountModel : EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string? Reason { get; private set; }
        public bool DiscountFinished { get; private set; }

        public CustomerDiscountModel(long productId, int discountRate, DateTime startDate, DateTime endDate, string? reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            DiscountFinished = false;
        }

        public void Edit(long productId, int discountRate, DateTime startDate, DateTime endDate, string? reason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public bool CheckIfDiscountFinished(DateTime StartDate, DateTime EndDate)
        {
            if (EndDate > StartDate)
            {
                return DiscountFinished = false;
            }

            return DiscountFinished = true;
        }
    }
}
