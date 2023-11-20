using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Shared
{
    public class UpdateCurrencyDTO
    {
        public string Name { get; set; }
        public decimal ChangeRate { get; set; }
        public string CurrencyCode { get; set; }
        public Guid CurrencyId { get; set; }
    }
}