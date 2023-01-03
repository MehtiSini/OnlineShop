﻿namespace MyFramework.Tools.Authentication
{
    public interface IZarinPalFactory
    {
        string Prefix { get; set; }

        PaymentResponse CreatePaymentRequest(string amount, string mobile, string email, string description,
            long orderId);

        VerificationResponse CreateVerificationRequest(string authority, string price);
    }
}