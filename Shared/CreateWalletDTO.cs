using Endava.TechCourse.BankApp.Domain.Models;

namespace Endava.TechCourse.BankApp.Shared
{
    public class CreateWalletDTO
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}