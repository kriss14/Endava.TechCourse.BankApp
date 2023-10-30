using Endava.TechCourseBankApp.Domain.Common;

namespace Endava.TechCourse.BankApp.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
    }
}