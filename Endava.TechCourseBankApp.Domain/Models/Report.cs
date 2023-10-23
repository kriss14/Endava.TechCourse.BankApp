using Endava.TechCourseBankApp.Domain.Common;

namespace Endava.TechCourseBankApp.Domain.Models
{
    public class Report: BaseEntity
    {
        public int ReportId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Payment> Payments { get; set; }
    }






}
