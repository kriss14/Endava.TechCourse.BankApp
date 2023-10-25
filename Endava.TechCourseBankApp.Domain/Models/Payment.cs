﻿using Endava.TechCourseBankApp.Domain.Common;

namespace Endava.TechCourseBankApp.Domain.Models
{
    public class Payment: BaseEntity
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public int TransactionId { get; set; }
    }
}