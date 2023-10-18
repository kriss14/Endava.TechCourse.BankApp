using Endava.TechCourseBankApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourseBankApp.Domain.Models
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ChangeRate { get; set; }

    }
}
