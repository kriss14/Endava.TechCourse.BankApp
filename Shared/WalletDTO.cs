using Endava.TechCourse.BankApp.Domain.Models;

namespace Endava.TechCourse.BankApp.Shared
{
    public class WalletDTO
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public string Type { get; set; }

        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}