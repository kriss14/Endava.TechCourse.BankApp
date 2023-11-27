using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.TechCourse.BankApp.Shared
{
    public class UpdateWalletDto
    {
        public decimal Amount { get; set; }
        public int Pincode { get; set; }
        public string Type { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid WalletId { get; set; }
    }
}