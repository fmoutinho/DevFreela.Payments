﻿using DevFreela.Payments.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Payments.Application.GetPayment
{
    public sealed class GetPaymentResponse
    {
        public Guid Id { get; init; }
        public int ProjectId { get; init; }
        public string CreaditCardNumber { get; init; }
        public string Cvv { get; init; }
        public DateOnly ExpiresAt { get; init; }
        public string FullName { get; init; }

        public static GetPaymentResponse FromEntity(Payment payment)
        {
            return new GetPaymentResponse
            {
                Id = payment.Id,
                CreaditCardNumber = payment.CreditCardNumber,
                Cvv = payment.Cvv,
                ExpiresAt = payment.ExpiresAt,
                FullName = payment.FullName
            };
        }
    }
}
