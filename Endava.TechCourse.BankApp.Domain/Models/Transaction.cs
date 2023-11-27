using Endava.TechCourse.BankApp.Domain.Common;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal ChangeRate { get; set; }
        public string Description { get; set; }
        public DateTime TransactionTime { get; set; }
        public Guid SourceWalletId { get; set; }
        public Guid DestinationWalletId { get; set; }
    }
}
