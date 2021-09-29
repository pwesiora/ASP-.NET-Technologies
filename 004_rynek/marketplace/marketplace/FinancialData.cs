using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public class BankData
    {
        private decimal _inflation;
        private decimal _tax;

        public decimal Inflation { get => _inflation; set => _inflation = value; }
        public decimal Tax { get => _tax; set => _tax = value; }
    }
}
