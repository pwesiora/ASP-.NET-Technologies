using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fvat
{
    public class Seller: Company
    {
        private string _accountNumber { get; set; }

        public Seller(string accountNumber, string name, string address, string nip) : base(name, address, nip)
        {
            if (accountNumber.All(char.IsDigit) && accountNumber.Length == 26)
                _accountNumber = accountNumber;
            else
                throw new ArgumentException();
        }
    }
}
