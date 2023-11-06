using System;

namespace Endava.TechCourse.BankApp.Shared
{
    public class TransactionDto
    {
        public string Id { get; set; }
        public string SourceWalletId { get; set; }
        public string DestinationWalletId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}