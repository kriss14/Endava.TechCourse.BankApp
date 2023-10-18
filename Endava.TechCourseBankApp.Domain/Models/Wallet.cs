using Endava.TechCourseBankApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourseBankApp.Domain.Models
{
    public class Wallet : BaseEntity
    { 
        public string Type { get; set; }
        public decimal Amount { get;} 
        public Currency Currency { get; set; }

    }
}
