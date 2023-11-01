using Endava.TechCourseBankApp.Domain.Common;

namespace Endava.TechCourseBankApp.Domain.Models
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ChangeRate { get; set; }

    }
}
