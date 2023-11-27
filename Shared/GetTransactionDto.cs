﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Shared
{
    public class GetTransactionDto
    {
        public Guid Id { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public decimal ChangeRate { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid IdOfAccepter { get; set; }
        public Guid IdOfSender { get; set; }
    }
}
