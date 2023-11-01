using Endava.TechCourseBankApp.Domain.Common;

namespace Endava.TechCourseBankApp.Domain.Models
{
    public class Wallet : BaseEntity
    { 
        public string Type { get; set; }
        public decimal Amount { get;} 
        public Currency Currency { get; set; }

    }
}
