using System;

namespace Endava.TechCourse.BankApp.Shared
{
    public class TransactionDto
    {
        public Guid SourceWalletId { get; set; }
        public Guid DestinationWalletId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Guid CurrencyId { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}